namespace Dynamo.Core.Entities.Base
{
    public interface IFullAudit<TKey> : IAudit<TKey>, ISoftDelete
    {

    }

    public interface IFullAudit : IFullAudit<long>
    {
    }
}
