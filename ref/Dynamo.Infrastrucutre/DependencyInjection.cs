using Dynamo.Context.Data;
using Dynamo.Context.Identity;
using Dynamo.Context.ModelConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Dynamo.Context
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDynamoInfrastructureDI(this IServiceCollection services)
        {
            //services.AddDbContext<DynamoContext>();

            services.AddIdentity<DynamoUser, DynamoRole>()
                .AddEntityFrameworkStores<DynamoContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<DynamoUserManager>();
            services.AddScoped<DynamoUserMapping>();
            services.AddScoped<DynamoRoleMapping>();
            services.AddScoped<IdentityUserRoleMapping>();

            return services;
        }
    }
}
