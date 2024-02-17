using System.ComponentModel.DataAnnotations.Schema;

namespace Dynamo.Core.Entities.Base
{
    public interface IEntity<TKey>
    {
        [Column(Order = 0)]
        TKey Id { get; set; }
    }

    public interface IEntity: IEntity<long>
    {

    }
}
