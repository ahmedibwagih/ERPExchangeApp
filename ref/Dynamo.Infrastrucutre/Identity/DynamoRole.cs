using System;
using System.Collections.Generic;
using Dynamo.Core.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace Dynamo.Context.Identity
{
    public class DynamoRole : IdentityRole,  IFullAudit<string>
    {
        public DynamoRole() : base()
        {

        }

        public string? CreateUser { get; set; }
        public string? CreateUserName { get; set; }
        public string? UpdateUser { get; set; }
        public string? UpdateUserName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public string DeleteUserId { get; set; }
        public bool? IsAdmin { get; set; }

        public ICollection<DynamoUser> Users { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
