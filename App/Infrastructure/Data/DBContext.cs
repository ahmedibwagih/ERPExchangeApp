﻿
using Dynamo.Context.Data;
using Dynamo.Context.Data.Extensions;
using Dynamo.Context.ModelConfiguration;
using Dynamo.Core.Other;
using Infrastructure.DataConfiguration;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Infrastructure.Data
{

    //    create proc GetClosestDelivery(@ResturantId as bigint  )
    //as
    //DECLARE @ResturantLocation geography;  
    //select @ResturantLocation = (geography::STPointFromText('POINT(' + CAST(Longtitude AS VARCHAR(20)) + ' ' + CAST(Latitude AS VARCHAR(20)) + ')', 4326))  from ResturantProfiles where id = @ResturantId

    //SELECT* from DeliveryProfileLocations
    //order by LastUpdatedDate,(geography::STPointFromText('POINT(' + CAST(Longtitude AS VARCHAR(20)) + ' ' + CAST(Latitude AS VARCHAR(20)) + ')', 4326)).STDistance(@ResturantLocation)

    public class DBContext : DynamoContext
    {
        private readonly DynamoSession session;
        private readonly UserConfiguration userConfiguration;
        private readonly RoleConfiguration roleConfiguration;
        private readonly UserRolesConfiguration userRolesConfiguration;

        public DBContext(DbContextOptions<DynamoContext> options
                        , DynamoSession session
                        , DynamoUserMapping dynamoUserMapping
                        , DynamoRoleMapping dynamoRoleMapping
                        , IdentityUserRoleMapping identityUserRoleMapping
                        , UserConfiguration userConfiguration
                        , UserRolesConfiguration userRolesConfiguration
                        , RoleConfiguration roleConfiguration
            ) : base(options, session, dynamoUserMapping, dynamoRoleMapping, identityUserRoleMapping)
        {
            this.session = session;
            this.userConfiguration = userConfiguration;
            this.roleConfiguration = roleConfiguration;
            this.userRolesConfiguration = userRolesConfiguration;
            //temperory solution to prevent deleted users, should be move to DynamoAuthorize or AppAuthorize
            if (this.session.UserId != null)
            {
                var user = this.Users.Find(this.session.UserId);
                if (user == null)
                {
                    throw new DynamoException("User not existed!");
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ApplyConfigurations(builder);
            SetProductMapping(builder);
            SetAttachmentMapping(builder);

        }

        private void SetProductMapping(ModelBuilder builder)
        {
            //builder.Entity<ProductAddition>()
            //.HasOne(bc => bc.Product)
            //.WithMany(c => c.ProductAdditions)
            //.HasForeignKey(bc => bc.ProductId);


         
        }

        private void SetAttachmentMapping(ModelBuilder builder)
        {
          
        }

        protected override void ApplyGlobalFilters(ModelBuilder builder)
        {
            base.ApplyGlobalFilters(builder);
        }

        protected override void EntityAdding(object entity)
        {
     
        }

        private void ApplyConfigurations(ModelBuilder builder)
        {
            builder.ApplyConfiguration(userConfiguration);
            builder.ApplyConfiguration(roleConfiguration);
            builder.ApplyConfiguration(userRolesConfiguration);
        }

    }
}
