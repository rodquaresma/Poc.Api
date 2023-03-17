using Microsoft.EntityFrameworkCore;
using PocApi.Business;
using PocApi.Business.Interfaces;
using PocApi.Data.Context;
using PocApi.Data.Interfaces;
using PocApi.Data.Repositories;
using PocApi.Data.UnityOfWork;
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

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnityOfWork, UnityOfWork>();

            return services;
        }

        public static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        public static void CreateDataBaseIfNotExist(this WebApplication webApplication)
        {
            using (IServiceScope _scope = webApplication.Services.CreateScope())
            {
                AppDbContext appDbContext = _scope.ServiceProvider.GetRequiredService<AppDbContext>();
                appDbContext.Database.EnsureCreated();
            }
        }
    }
}
