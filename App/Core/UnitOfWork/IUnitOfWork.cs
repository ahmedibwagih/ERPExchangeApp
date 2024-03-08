using System.Threading.Tasks;
using Core.Repositories.Auth;
using Core.Repositories.Base;
using Core.Repositories.privilage;


namespace Core.UnitOfWork
{
    public interface IUnitOfWork
    {
      
        IPermissionRepository Permission { get; }
        IScreenRepository Screen { get; }
        IPrivilageRepository Privilage { get; }
        IPrivilageTypeRepository PrivilageType { get; }


        Task<int> CompleteAsync();

        void BeginTran();

        void CommitTran();

        void RollbackTran();

        object GetRepositoryByName(string name);
    }
}
