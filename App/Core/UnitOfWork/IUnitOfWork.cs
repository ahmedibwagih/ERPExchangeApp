using System.Threading.Tasks;
using Core.Repositories.Auth;
using Core.Repositories.Base;
using Core.Repositories.privilage;
using Core.Repositories.LookUps;

namespace Core.UnitOfWork
{
    public interface IUnitOfWork
    {

        IBanksRepository Banks { get; }
        ITransferPurposesRepository TransferPurposes { get; }
        IJobsRepository Jobs { get; }
        IIdentitySourcesRepository IdentitySources { get; }
        ICurrenciesRepository Currencies { get; }
        ICountriesRepository Countries { get; }

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
