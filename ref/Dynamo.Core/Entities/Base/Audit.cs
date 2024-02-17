using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dynamo.Core.Entities.Base
{

    public class Audit<TKey> : Entity<TKey>, IAudit<TKey>
    {
        [MaxLength(450)] [Column(Order = 1)] public string? CreateUser { get; set; }
        [MaxLength(256)] [Column(Order = 2)] public string? CreateUserName { get; set; }
        [MaxLength(450)] [Column(Order = 3)] public string? UpdateUser { get; set; }
        [MaxLength(256)] [Column(Order = 4)] public string? UpdateUserName { get; set; }
        [Column(Order = 5)] public DateTime? CreateDate { get; set; }
        [Column(Order = 6)] public DateTime? UpdateDate { get; set; }
    }

    public class Audit : Audit<long>
    {
    }
}
