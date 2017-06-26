using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Akasa.Data.DBGen
{
    public class Startup
    {
        private IConfigurationRoot _configuration { get; }

        public Startup()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .AddJsonFile("appSettings.local.overrides.json", true);

            _configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var dbMigrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.FullName;
            services.AddDbContext<AkasaDBContext>(options => options.UseMySql(connectionString, op => op.MigrationsAssembly(dbMigrationsAssembly)));
        }
    }
}
