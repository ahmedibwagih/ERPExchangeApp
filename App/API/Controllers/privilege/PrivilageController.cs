using System.Threading.Tasks;
using Application.Core.DTOs.Authentication;
using Application.Core.DTOs.LookUps;
using Application.Core.DTOs.privilege;
using Application.Core.DTOs.User;
using Application.Core.Services;
using Application.Core.Services.privilage;
using Application.Services;
using Application.Services.LookUps;
using Core.DTOs;
using Core.Entities.LookUps;
using Core.Entities.privilege;
using Core.Other;
using Dynamo.Context.Identity;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers.LookUps
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivilageController : ControllerBase
    {

        private readonly IPrivilageService service;
        private readonly IAuthenticateService authservice;
        private readonly DynamoUserManager userManager;
        public PrivilageController(IPrivilageService service, IAuthenticateService authservice, DynamoUserManager userManager)
        {
            this.service = service;
            this.authservice = authservice;
            this.userManager = userManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
        public async Task<PagingResultDto<PrivilageTypeDto>> GetPrivilageTypes(long screensId)
        {
            return await service.GetPrivilageTypes(screensId);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
        public async Task<PagingResultDto<PrivilageTypeDto>> GetAllPrivilageTypes()
        {
            return await service.GetAllPrivilageTypes();
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
        public async Task<PagingResultDto<ScreensDto>> GetScreens()
        {
            return await service.GetScreens();
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
        public async Task<Boolean> CheckAuth(long PrivilageTypeId,string userid, long screenid)
        {
           return await service.CheckAuth(PrivilageTypeId, userid,  screenid);
        }
       

                 [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
        public async Task<Boolean> CheckAuthByName(string userId, string screenName, string PrivilageTypeName)
        {
            return await service.CheckAuthByName(userId, screenName, PrivilageTypeName);
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
