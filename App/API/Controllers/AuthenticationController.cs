using System.Threading.Tasks;
using Application.Core.DTOs.Authentication;
using Application.Core.DTOs.LookUps;
using Application.Core.DTOs.User;
using Application.Core.Services;
using Application.Services;
using Application.Services.LookUps;
using Core.DTOs;
using Core.Other;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService authenticateService;
        private readonly IUserService userService;

        public AuthenticationController(IAuthenticateService authenticateService, IUserService userService)
        {
            this.authenticateService = authenticateService;
            this.userService = userService;

        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<TokenDto>> Login([FromBody] LoginDto model)
        {
            return Ok (await authenticateService.Login(model));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserDto input)
        {
            return await userService.CreateUser(input);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
       // [AppAuthorize]
        public async Task<SessionDto> GetUserSession()
        {
            return await userService.GetUserSession();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
        //[AppAuthorize]
        public async Task<PagingResultDto<UserDto>> GetUsers()
        {
            return await userService.GetUsers(new Core.DTOs.PagingInputDto() {PageSize=1000,PageNumber=1 });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
        public async Task<UserDto> UpdateUser([FromBody] UserDto input)
        {
            return await userService.UpdateUser(input);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
        public async Task UpdateDelete(string id)
        {
             await userService.Delete(id);
        }

    }
}
