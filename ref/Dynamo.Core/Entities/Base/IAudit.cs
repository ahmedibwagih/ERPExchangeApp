#nullable enable
using System.ComponentModel.DataAnnotations.Schema;

namespace Dynamo.Core.Entities.Base
{
    public interface IAudit<TKey> : IEntity<TKey>
    {
        [Column(Order = 1)] string? CreateUser { get; set; }
        [Column(Order = 2)] string? CreateUserName { get; set; }
        [Column(Order = 3)] string? UpdateUser { get; set; }
        [Column(Order = 4)] string? UpdateUserName { get; set; }
        [Column(Order = 5)] DateTime? CreateDate { get; set; }
        [Column(Order = 6)] DateTime? UpdateDate { get; set; }
    }

    public interface IAudit : IAudit<long>
    {
    }

}
