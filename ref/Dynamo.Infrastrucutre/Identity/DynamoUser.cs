using System;
using System.Collections.Generic;
using Dynamo.Core.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace Dynamo.Context.Identity
{
    public class DynamoUser : IdentityUser, IFullAudit<string>
    {
        public string FullName { get; set; }
        public long? TypeId { get; set; }
        public int? Type { get; set; }
        public string? CreateUser { get; set; }
        public string? CreateUserName { get; set; }
        public string? UpdateUser { get; set; }
        public string? UpdateUserName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public string? DeleteUserId { get; set; }
        public long? JobId { get; set; }

        public ICollection<DynamoRole> UserRoles { get; set; }

    }
}
