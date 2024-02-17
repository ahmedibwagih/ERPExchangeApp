using Application.Core.DTOs.Role;
using Core.DTOs;

namespace Application.Core.Services
{
    public interface IRoleService
    {
        Task<PagingResultDto<RoleDto>> GetAll(PagingInputDto pagingInputDto);
        Task<RoleDto> GetById(string id);
        Task Delete(string id);
        Task<RoleDto> Create(RoleDto input);
        Task<RoleDto> Update(RoleDto input);
        Task<IList<PermissionDto>> GetAllPermissions();
        Task<IList<PermissionTreeDto>> GetAllPermissionsTree();
    }
}
