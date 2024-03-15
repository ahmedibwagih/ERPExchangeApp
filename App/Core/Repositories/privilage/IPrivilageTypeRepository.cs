using Core.Entities.privilege;
using Core.Repositories.Base;
using Dynamo.Core.Entities;
using System.Threading.Tasks;

namespace Core.Repositories.privilage
{
    public interface IPrivilageRepository : IRepository<Privilage>
    {
        Task<bool> CheckAuth(long PrivilageTypeId, long jobid, long screenid);

    }
}
