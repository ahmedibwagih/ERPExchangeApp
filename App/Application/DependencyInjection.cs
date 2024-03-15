using Application.Core.Services;
using Application.Core.Services.LookUps;
using Application.Core.Services.privilage;
using Application.Services;
using Application.Services.LookUps;
using Application.Services.privilage;
using Core;
using Core.Entities.LookUps;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services, AppSettings config)
        {
            services.AddSingleton(config);
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped(typeof(IService<,,,,>), typeof(BaseService<,,,,>));
            services.AddScoped<IUserService, UserService>();


            //LookUps
            services.AddScoped< IBanksService, BanksService>();
            services.AddScoped< ICountriesService, CountriesService>();
            services.AddScoped< ICurrenciesService, CurrenciesService>();
            services.AddScoped< IIdentitySourcesService, IdentitySourcesService>();
            services.AddScoped< IJobsService, JobsService>();
            services.AddScoped < ITransferPurposesService, TransferPurposesService>();
            services.AddScoped<IPrivilageService, PrivilageService>();
            return services;
        }
    }
}
