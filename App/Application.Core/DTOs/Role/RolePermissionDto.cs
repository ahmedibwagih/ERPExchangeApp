using Core.DTOs;

namespace Application.Core.DTOs.Role
{
    public class RolePermissionDto : EntityDto
    {
        public long PermissionId { get; set; }

        public string PermissionName { get; set; }
    }
}
