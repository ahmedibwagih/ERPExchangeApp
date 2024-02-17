﻿using Core;
using Core.Repositories.Auth;
using Core.Repositories.Base;
using Core.UnitOfWork;
using Dynamo.Context.Data;
using Dynamo.Context.Identity;
using Dynamo.Context.ModelConfiguration;
using Dynamo.Core.Other;
using Infrastructure.Data;
using Infrastructure.DataConfiguration;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, AppSettings settings)
        {
            services.AddDbContext<DBContext>(
                m => m.UseSqlServer(settings.ConnectionStrings.Db,x=>x.UseNetTopologySuite()));

            services.AddDbContext<DynamoContext>(
                m => m.UseSqlServer(settings.ConnectionStrings.Db, x => x.UseNetTopologySuite()));

            services.Configure<IdentityOptions>(option => {
                option.Password.RequiredLength = 6;
                option.Password.RequireUppercase = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireDigit = true;
                option.Password.RequireNonAlphanumeric = true;
                option.User.RequireUniqueEmail = false;
            }
            );
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<DynamoUserManager>();
            services.AddScoped<DynamoSession>();
            services.AddScoped(typeof(IPasswordHasher<>), typeof(PasswordHasher<>));
            services.AddScoped<RoleConfiguration>();
            services.AddScoped<UserConfiguration>();
            services.AddScoped<UserRolesConfiguration>();
            services.AddScoped<DynamoUserMapping>();
            services.AddScoped<DynamoRoleMapping>();
            services.AddScoped<IdentityUserRoleMapping>();

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IPermissionRepository), typeof(PermissionRepository));
            services.AddScoped(typeof(IRolePermissionRepository<RolePermission>), typeof(RolePermissionRepository));
            services.AddScoped(typeof(IUserRoleRepository<IdentityUserRole<string>>), typeof(UserRoleRepository));
            return services;
        }
    }
}
