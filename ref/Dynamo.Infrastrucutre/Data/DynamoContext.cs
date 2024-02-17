using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dynamo.Context.Data.Extensions;
using Dynamo.Context.Identity;
using Dynamo.Context.ModelConfiguration;
using Dynamo.Core.Entities;
using Dynamo.Core.Entities.Base;
using Dynamo.Core.Other;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dynamo.Context.Data
{
    public class DynamoContext : IdentityDbContext<DynamoUser, DynamoRole, string>
    {
        private readonly DynamoSession session;
        private readonly DynamoUserMapping dynamoUserMapping;
        private readonly DynamoRoleMapping dynamoRoleMapping;
        private readonly IdentityUserRoleMapping identityUserRoleMapping;

        //protected LogData LogData;

        public DynamoContext(DbContextOptions<DynamoContext> options
                        , DynamoSession session
                        , DynamoUserMapping dynamoUserMapping
                        , DynamoRoleMapping dynamoRoleMapping
                        , IdentityUserRoleMapping identityUserRoleMapping
            ) : base(options)
        {
            this.session = session;
            this.dynamoUserMapping = dynamoUserMapping;
            this.dynamoRoleMapping = dynamoRoleMapping;
            this.identityUserRoleMapping = identityUserRoleMapping;
            //LogData = new LogData();
        }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ApplyGlobalFilters(builder);
            ApplyModelMapping(builder);
            ApplyGlobalIndexes(builder);

            IgnoreUnneccesaryTables(builder);
        }

        private void IgnoreUnneccesaryTables(ModelBuilder builder)
        {
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();
        }

        private void ApplyModelMapping(ModelBuilder builder)
        {
            builder.ApplyConfiguration(dynamoUserMapping);
            builder.ApplyConfiguration(dynamoRoleMapping);
            builder.ApplyConfiguration(identityUserRoleMapping);
        }

        protected virtual void ApplyGlobalFilters(ModelBuilder builder)
        {
            builder.SetQueryFilterByInterfce<ISoftDelete>(p => !p.IsDeleted);
        }

        private static void ApplyGlobalIndexes(ModelBuilder builder)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            PrepareChanges();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void PrepareChanges()
        {
            var changes = from e in ChangeTracker.Entries()
                          where e.State != EntityState.Unchanged
                          select e;

            foreach (var change in changes)
            {
                switch (change.State)
                {
                    case EntityState.Added:
                    {
                        var entity = change.Entity;
                        EntityAdding(entity);
                        if (entity is IAudit<long> audit)
                        {
                            audit.CreateUser = session.UserId;
                            audit.CreateUserName = session.UserName;
                            audit.CreateDate = DateTime.Now;
                        }
                        else if (entity is IAudit audit2)
                        {
                            audit2.CreateUser = session.UserId;
                            audit2.CreateUserName = session.UserName;
                            audit2.CreateDate = DateTime.Now;
                        }
                        break;
                    }
                    case EntityState.Modified:
                    {
                        switch (change.Entity)
                        {
                            case IAudit audit 
                            when audit is IFullAudit { IsDeleted: false } || audit is not IFullAudit audit1:
                                audit.UpdateUser = session.UserId;
                                audit.UpdateUserName = session.UserName;
                                audit.UpdateDate = DateTime.Now;
                                break;
                            case IAudit<long> audit
                            when audit is IFullAudit { IsDeleted: false } || audit is not IFullAudit audit1:
                                audit.UpdateUser = session.UserId;
                                audit.UpdateUserName = session.UserName;
                                audit.UpdateDate = DateTime.Now;
                                break;
                            case IFullAudit { IsDeleted: true } entity:
                            entity.DeleteUserId = session.UserId;
                            break;
                        }

                        break;
                    }
                    case EntityState.Deleted:
                        break;
                }
            }
        }

        protected virtual void EntityAdding(object entity)
        {

        }
    }
}
