﻿using System.Threading.Tasks;
using Application.Core.DTOs.Authentication;
using Application.Core.DTOs.LookUps;
using Application.Core.DTOs.privilege;
using Application.Core.DTOs.User;
using Application.Core.Services;
using Application.Services;
using Application.Services.LookUps;
using Core.DTOs;
using Core.Entities.LookUps;
using Core.Entities.privilege;
using Core.Other;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.LookUps
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivilageController : ControllerBase
    {

        private readonly IService<Privilage, PrivilageDto, PrivilageDto, PrivilageDto, PrivilageDto> service;

        public PrivilageController(IService<Privilage, PrivilageDto, PrivilageDto, PrivilageDto, PrivilageDto> service)
        {
            this.service = service;
        }

     
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
        public async Task<PagingResultDto<PrivilageDto>> GetAll([FromQuery] PagingInputDto pagingInputDto)
        {
            return await service.GetAllPaging(pagingInputDto);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
        public async Task<PrivilageDto> Get(long id)
        {
            return await service.GetById(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
        public async Task<ActionResult<PrivilageDto>> Create([FromBody] PrivilageDto input)
        {
            return await service.Create(input);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
        public async Task Update([FromBody] PrivilageDto input)
        {
            await service.Update(input);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
        public async Task Delete(long id)
        {
            await service.Delete(id);
        }

    }
}