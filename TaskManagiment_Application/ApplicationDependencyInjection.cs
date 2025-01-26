using Microsoft.Extensions.DependencyInjection;
using TaskManagiment_Application.Service.Impl;
using TaskManagiment_Application.Service;
using TaskManagiment_DataAccess.Claim;
using Microsoft.AspNetCore.Hosting;

namespace TaskManagiment_Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddServices(env);

            services.RegisterAutoMapper();

            services.RegisterCashing();

            return services;
        }

        private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IUserService, UserService>();
        }

        private static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(IMappingProfilesMarker));
        }

        private static void RegisterCashing(this IServiceCollection services)
        {
            services.AddMemoryCache();
        }
    }
}
