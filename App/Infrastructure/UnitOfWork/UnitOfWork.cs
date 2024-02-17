﻿using System;
using System.Threading.Tasks;
using Core.Other;
using Core.Repositories.Auth;
using Core.Repositories.Base;
using Core.UnitOfWork;
using Dynamo.Core.Other;
using Infrastructure.Data;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext context;

       

        public IPermissionRepository Permission { get; }
       

        public UnitOfWork(DBContext context
            , IPermissionRepository permission
           
            )
        {
            this.context = context;
           
            Permission = permission;
          
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
