using System.ComponentModel.DataAnnotations.Schema;
using Dynamo.Core.Entities;
using Dynamo.Core.Entities.Base;

namespace Dynamo.Context.Identity
{
    public class RolePermission : Entity
    {
        public string RoleId { get; set; }

        [ForeignKey("RoleId")]
        public DynamoRole Role { get; set; }
        public long PermissionId { get; set; }

        [ForeignKey("PermissionId")]
        public Permission Permission { get; set; }
        public string PermissionName { get; set; }
    }
}
