using System.ComponentModel.DataAnnotations;
using Dynamo.Core.Entities.Base;

namespace Dynamo.Core.Entities
{
    public class Notification : Audit
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Message { get; set; }
        [Required]
        public int NotificationType { get; set; }
        public string DataId { get; set; }
        public string DataDesc { get; set; }
        public bool IsRead { get; set; }
        public bool IsPending { get; set; }

    }
}
