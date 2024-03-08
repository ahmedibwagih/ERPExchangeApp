﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Core.DTOs.Authentication;
using Application.Core.DTOs.LookUps;
using Application.Core.Services;
using Application.Core.Services.LookUps;
using Core;
using Core.DTOs;
using Core.Entities.LookUps;
using Core.Other;
using Core.UnitOfWork;
using Dynamo.Context.Identity;
using Dynamo.Core.Entities.Base;
using Dynamo.Core.Other;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using static Google.Apis.Requests.BatchRequest;

namespace Application.Services.LookUps
{
    public class BanksService : BaseService<Banks, BanksDto, BanksDto, BanksDto, BanksDto>, IBanksService
    {
        private readonly DynamoSession session;

        public BanksService(IUnitOfWork unitOfWork,
       DynamoSession session) : base(unitOfWork)
        {
            
            this.session = session;
        }

        public override async Task<BanksDto> GetById(long id)
        {
            var response = await base.GetById(id);
            return response;
        }

        //protected async override Task<bool> OnCreated(Banks entity, BanksDto dto)
        //{
        //    await this.attachmentService.Save(entity.Id, AttachmentTypeEnum.Banks, dto.Attachments, true);

        //    return await base.OnCreated(entity, dto);
        //}

        //protected async override Task<bool> OnUpdated(Banks entity, BanksDto dto)
        //{
        //    await this.attachmentService.Save(entity.Id, AttachmentTypeEnum.Banks, dto.Attachments, false);

        //    return await base.OnUpdated(entity, dto);
        //}

        //public virtual async Task<PagingResultDto<BanksDto>> GetActiveBankssPaging(ActiveBanksPagingInputDto pagingInputDto)
        //{
        //    var result = await Repository.GetAllPagingAsync(new PagingInputDto());

        //    var list = Mapper.MapperObject.Mapper.Map<IList<BanksInfoDto>>(result.Item1);

        //    var response = new PagingResultDto<BanksInfoDto>
        //    {
        //        Result = list,
        //        Total = result.Item2
        //    };

        //    foreach (var item in response.Result)
        //    {
        //        item.Attachments = await attachmentService.GetAttachments(item.Id, AttachmentTypeEnum.Banks);
        //    }

        //    return response;
        //}
  
    
    }
}
