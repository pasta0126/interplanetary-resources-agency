using Ira.Repositories;
using Ira.Repositories.Context;
using Ira.Repositories.Interfaces;
using Ira.Services;
using Ira.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ira.Api.Config
{
    public static class AppConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfigurationRoot config)
        {
            services.AddDbContext<IraContext>(options =>
                options.UseSqlServer(config.GetConnectionString("IraDBLocal")));

            // Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IShipRepository, ShipRepository>();
            services.AddScoped<IMissionRepository, MissionRepository>();

            // Services
            services.AddScoped<IMissionService, MissionService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IFakeService, FakeService>();
        }

        public static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();
        }
    }
}
