using System;
using System.Threading.Tasks;
using Core.Entities.LookUps;
using Core.Other;
using Core.Repositories.Auth;
using Core.Repositories.Base;
using Core.Repositories.LookUps;
using Core.Repositories.privilage;
using Core.UnitOfWork;
using Dynamo.Core.Other;
using Infrastructure.Data;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext context;



        public IBanksRepository Banks { get; }
        public ICountriesRepository Countries { get; }
        public ICurrenciesRepository Currencies { get; }
        public IIdentitySourcesRepository IdentitySources { get; }
        public IJobsRepository Jobs { get; }
        public ITransferPurposesRepository TransferPurposes { get; }

        public IPermissionRepository Permission { get; }
        public IScreenRepository Screen { get; }
        public IPrivilageRepository Privilage { get; }
        public IPrivilageTypeRepository PrivilageType { get; }




        public UnitOfWork(DBContext context
            , IPermissionRepository permission
            , IScreenRepository screen
             , IPrivilageRepository privilage
             , IPrivilageTypeRepository privilageType
            , IBanksRepository banks
            , ICountriesRepository countries
            , ICurrenciesRepository currencies
            , IIdentitySourcesRepository identitySources
            , IJobsRepository jobs
            , ITransferPurposesRepository transferPurposes
            )
        {
            this.context = context;
            Permission = permission;
            Screen= screen;
            Privilage= privilage;
            PrivilageType= privilageType;
            Banks = banks;
            Countries = countries;
            Currencies = currencies;
            IdentitySources = identitySources;
            Jobs = jobs;
            TransferPurposes = transferPurposes;
        }

        public async Task<int> CompleteAsync()
        {
            try
            {
                return await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                RollbackTran();
                throw;
            }

        }

        public object GetRepositoryByName(string name)
        {
            var type = GetType();
            var info = type.GetProperty(name);
            if (info == null)
                throw new DynamoException(AppMessages.InternalError +  name + "." + type.FullName);

            return info.GetValue(this, null);
        }

        public async void BeginTran()
        {
            await context.Database.BeginTransactionAsync();
        }

        public async void CommitTran()
        {
            await context.Database.CommitTransactionAsync();
        }

        public async void RollbackTran()
        {
            var transaction = context.Database.CurrentTransaction;
            if (transaction != null)
                await context.Database.RollbackTransactionAsync();
        }
    }
}
