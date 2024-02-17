using Application.Core.DTOs.Authentication;

namespace Application.Core.Services
{
    public interface IAuthenticateService
    {
        Task<object> Login(LoginDto loginDto);

        

    }
}
