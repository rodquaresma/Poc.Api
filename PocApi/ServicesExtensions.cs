using PocApi.Business;
using PocApi.Business.Interfaces;
using PocApi.Data.Interfaces;
using PocApi.Data.Repositories;
using PocApi.Services;
using PocApi.Services.Interfaces;

namespace PocApi.Api
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<IUserBusiness, UserBusiness>();

            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
