using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dynamo.Core.Entities.Base
{
    public class FullAudit<TKey> : Audit<TKey>, IFullAudit<TKey>
    {
        [Column(Order = 7)]
        public bool IsDeleted { get; set; }
        [MaxLength(450)]
        [Column(Order = 8)]
        public string? DeleteUserId { get; set; }

    }

    public class FullAudit : FullAudit<long>
    {
    }
}
