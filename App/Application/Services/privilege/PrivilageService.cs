using System;
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
using Application.Core.DTOs.privilege;
using Application.Core.Services;
using Application.Core.Services.LookUps;
using Application.Core.Services.privilage;
using Core;
using Core.DTOs;
using Core.Entities.LookUps;
using Core.Entities.privilege;
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

namespace Application.Services.privilage
{
    public class PrivilageService : BaseService<Privilage, PrivilageDto, PrivilageDto, PrivilageDto, PrivilageDto>, IPrivilageService
    {
        private readonly DynamoSession session;

        public PrivilageService(IUnitOfWork unitOfWork,
       DynamoSession session) : base(unitOfWork)
        {
            
            this.session = session;
        }

        public override async Task<PrivilageDto> GetById(long id)
        {
            var response = await base.GetById(id);
            return response;
        }

    
  
    
    }
}
