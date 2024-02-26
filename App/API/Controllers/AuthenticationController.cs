using System.Threading.Tasks;
using Application.Core.DTOs.Authentication;
using Application.Core.Services;
using Application.Services;
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


        public AuthenticationController(
            IAuthenticateService authenticateService
            )
        {
            this.authenticateService = authenticateService;

        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<TokenDto>> Login([FromBody] LoginDto model)
        {
            return Ok (await authenticateService.Login(model));
        }
        
    }
}
