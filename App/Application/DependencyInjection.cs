using Application.Core.Services;
using Application.Services;
using Core;
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

            return services;
        }
    }
}
