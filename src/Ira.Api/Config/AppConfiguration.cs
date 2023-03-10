using Ira.Services;

namespace Ira.Api.Config
{
    public static class AppConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
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
