using System;
using System.Linq;
using Application.Core.DTOs.Authentication;
using Application.Core.DTOs.privilege;
using Application.Core.DTOs.Role;
using Application.Core.DTOs.User;
using AutoMapper;
using Core.DTOs;

using Core.Entities.privilege;
using Core.Other;
using Dynamo.Context.Identity;
using Dynamo.Core.Entities;
using Dynamo.Core.Other;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {
        public Point GetPoint(string longitude,string latitude)
        {
            var goemetryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            Point Location = null;
            try
            {
                Location = goemetryFactory.CreatePoint(new Coordinate(double.Parse(longitude), double.Parse(latitude)));
            }
            catch (System.Exception) { }
            return Location;
        }

      


        public MappingProfile()
        {
            CreateMap<UserDto, DynamoUser>()
                .ForMember(m => m.UserRoles, op => op.Ignore())
                .ForMember(m => m.Id, op => op.Ignore());

            CreateMap<DynamoUser, UserDto>();
            CreateMap<DynamoUser, UserAllDto>();

            CreateMap<UserUpdateDto, DynamoUser>()
                .ForMember(m => m.UserRoles, op => op.Ignore())
                .ForMember(m => m.Id, op => op.Ignore());

            CreateMap<DynamoUser, UserUpdateDto>();

          
            CreateMap<IdentityUserRole<string>, UserRoleDto>().ReverseMap();

            CreateMap<DynamoRole, UserRoleDto>()
                .ForMember(m => m.RoleId, op => op.MapFrom(mp => mp.Id))
                .ForMember(m => m.RoleName, op => op.MapFrom(mp => mp.Name))
                .ReverseMap();

            CreateMap<RoleDto, DynamoRole>()
                .ForMember(m => m.Id, op => op.Ignore())
                .ForMember(m => m.RolePermissions, op => op.Ignore())
                ;
            CreateMap<DynamoRole, RoleDto>();

            CreateMap<RolePermissionDto, RolePermission>();
            CreateMap<RolePermission, RolePermissionDto>();

          

            CreateMap<Permission, PermissionDto>().ReverseMap();
            CreateMap<DynamoUser, SessionDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Privilage, PrivilageDto>();
            CreateMap<PrivilageDto, Privilage>();

            CreateMap<Screens, ScreensDto>();
            CreateMap<ScreensDto, Screens>();

            CreateMap<PrivilageType, PrivilageTypeDto>();
            CreateMap<PrivilageTypeDto, PrivilageType>();
        }
    }
}
