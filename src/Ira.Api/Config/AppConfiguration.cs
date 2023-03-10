using Ira.Repositories;
using Ira.Repositories.Context;
using Ira.Services;
using Microsoft.EntityFrameworkCore;

namespace Ira.Api.Config
{
    public static class AppConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDbContext<IraContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IraDBLocal")));

            // Repositories
            services.AddScoped<MissionRepository, MissionRepository>();

            // Services
            services.AddScoped<MissionService, MissionService>();
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
