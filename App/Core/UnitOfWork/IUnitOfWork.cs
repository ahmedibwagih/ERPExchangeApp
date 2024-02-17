using System.Threading.Tasks;
using Core.Repositories.Auth;
using Core.Repositories.Base;


namespace Core.UnitOfWork
{
    public interface IUnitOfWork
    {
      
        IPermissionRepository Permission { get; }
       


        Task<int> CompleteAsync();

        void BeginTran();

        void CommitTran();

        void RollbackTran();

        object GetRepositoryByName(string name);
    }
}
