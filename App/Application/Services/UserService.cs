﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Application.Core.DTOs.Authentication;
using Application.Core.DTOs.User;
using Application.Core.Services;
using Application.Mapper;
using AutoMapper;
using Core.DTOs;
using Core.Other;
using Core.Repositories.Auth;
using Core.UnitOfWork;
using Dynamo.Context.Identity;
using Dynamo.Core.Other;
using Infrastructure.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AppMessages = Core.Other.AppMessages;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly DynamoUserManager userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRoleRepository<IdentityUserRole<string>> userRole;
        private readonly DynamoSession dynamoSession;


        public UserService(DynamoUserManager userManager
            , IUnitOfWork unitOfWork
            , IUserRoleRepository<IdentityUserRole<string>> userRole
            , DynamoSession dynamoSession

            )
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
            this.userRole = userRole;
            this.dynamoSession = dynamoSession;

        }
        public virtual async Task<PagingResultDto<UserAllDto>> GetAll(PagingInputDto pagingInputDto)
        {
            var query = userManager.Users.AsQueryable();

            if (!string.IsNullOrEmpty(pagingInputDto.Filter))
            {
                var filter = pagingInputDto.Filter;
                query = query
                    .Where(u => u.UserName.Contains(filter) ||
                    u.Email.Contains(filter) ||
                    u.FullName.Contains(filter) ||
                    u.PhoneNumber.Contains(filter));
            }

            var order = query.OrderBy(pagingInputDto.OrderByField + " " + pagingInputDto.OrderType);

            var page = order.Skip((pagingInputDto.PageNumber * pagingInputDto.PageSize) - pagingInputDto.PageSize).Take(pagingInputDto.PageSize);

            var total = await query.CountAsync();

            var list = MapperObject.Mapper
                .Map<IList<UserAllDto>>(await page.ToListAsync());

            var response = new PagingResultDto<UserAllDto>
            {
                Result = list,
                Total = total
            };

            return response;
        }


        public async Task<UserDto> GetById(string id)
        {
            var entity = await userManager.Users
                .Include(x => x.UserRoles)
                .FirstOrDefaultAsync(x => x.Id == id);
            var response = MapperObject.Mapper.Map<UserDto>(entity);

            return response;
        }


        public async Task<UserDto> GetByIdLight(string id)
        {
            var entity = await userManager.Users
                .FirstOrDefaultAsync(x => x.Id == id);
            var response = MapperObject.Mapper.Map<UserDto>(entity);

            return response;
        }

        public async Task Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            user.IsDeleted = true;

            await userManager.UpdateAsync(user);
        }
        public async Task UndoDelete(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            user.IsDeleted = false;

            await userManager.UpdateAsync(user);
        }

        public async Task<UserDto> CreateUser(UserDto input)
        {
            var userExists = await userManager.FindByEmailAsync(input.Email);
            if (userExists != null)
                throw new DynamoException(AppMessages.EMailAlreadyExisted);

            userExists = await userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == input.PhoneNumber);
            if (userExists != null)
                throw new DynamoException(AppMessages.PhoneAlreadyExisted);

            var user = MapperObject.Mapper.Map<DynamoUser>(input);

            unitOfWork.BeginTran();

            await userManager.CreateAsync(user, input.Password);
            input.Id = user.Id;

            var userRoles = MapperObject.Mapper.Map<List<IdentityUserRole<string>>>(input.UserRoles);
            foreach (var role in userRoles)
            {
                role.UserId = user.Id;
            }

            await unitOfWork.CompleteAsync();

            await userRole.AddRangeAsync(userRoles);

            unitOfWork.CommitTran();

            return input;
        }

        public async Task<UserUpdateDto> Update(UserUpdateDto input)
        {
            var entity = await userManager.Users.FirstOrDefaultAsync(x => x.Id == input.Id);

            if (entity == null)
                throw new DynamoException(AppMessages.RecordNotExisted);

            MapperObject.Mapper.Map(input, entity);

            unitOfWork.BeginTran();

            await userManager.UpdateAsync(entity);

            var existedRoles = await userRole.GetUserRoleIdsArrayAsync(input.Id);
            var newRoles = MapperObject.Mapper.Map<List<IdentityUserRole<string>>>(input.UserRoles.Where(x => !existedRoles.Contains(x.RoleId)));
            newRoles.ForEach(x => x.UserId = input.Id);
            await userRole.AddRangeAsync(newRoles);

            //delete removed roles
            var rolesIds = input.UserRoles.Select(x => x.RoleId).ToArray();
            var removedRoles = await userRole.GetUserRoleRemovedIdsByAsync(input.Id, rolesIds);
            await userRole.DeleteAsync(removedRoles.AsEnumerable());

            await unitOfWork.CompleteAsync();
            unitOfWork.CommitTran();

            return input;
        }

        public async Task<UserUpdateDto> UpdateWithoutChildren(UserUpdateDto input)
        {
            var entity = await userManager.Users.FirstOrDefaultAsync(x => x.Id == input.Id);

            if (entity == null)
                throw new DynamoException(AppMessages.RecordNotExisted);

            MapperObject.Mapper.Map(input, entity);

            await userManager.UpdateAsync(entity);

            await unitOfWork.CompleteAsync();

            return input;
        }

        public async Task<bool> ResetPassword(ResetPasswordDto input)
        {
            var user = await userManager.FindByIdAsync(dynamoSession.UserId);

            if (user == null)
                throw new DynamoException(AppMessages.RecordNotExisted);

            if (!await userManager.CheckPasswordAsync(user, input.OldPassword))
                throw new DynamoException(AppMessages.Credential);

            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            await userManager.ResetPasswordAsync(user, token, input.NewPassword);

            return true;
        }

        public async Task<bool> CompleteForgetPassword(string userId, string newPassword)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
                throw new DynamoException(AppMessages.RecordNotExisted);

            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            await userManager.ResetPasswordAsync(user, token, newPassword);

            return true;
        }

        public async Task<SessionDto> GetUserSession()
        {
            var (user, permissions) = await userManager.GetUserSession(dynamoSession.UserId);

            var response = MapperObject.Mapper.Map<SessionDto>(user);

    
            return response;

        }
        public async Task<UserAllDto[]> GetUsersPermission(string permission)
        {
            var users = await userManager.GetUsersPermission(permission);
            var response = MapperObject.Mapper.Map<UserAllDto[]>(users);
            return response;
        }

  
    }
}