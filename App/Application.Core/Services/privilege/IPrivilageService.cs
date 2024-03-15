using Application.Core.DTOs.privilege;
using Core.DTOs;
using Core.Entities.privilege;

namespace Application.Core.Services.privilage
{
    public interface IPrivilageService :IService<Privilage, PrivilageDto, PrivilageDto, PrivilageDto, PrivilageDto>
    {
        public  Task<PagingResultDto<PrivilageTypeDto>> GetPrivilageTypes(long screensId);
        public  Task<PagingResultDto<ScreensDto>> GetScreens();
        public Task<PagingResultDto<PrivilageTypeDto>> GetAllPrivilageTypes();
        public Task<Boolean> CheckAuth(long PrivilageTypeId, string userId, long screenid);
    }
}
