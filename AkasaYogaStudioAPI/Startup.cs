using System.IO;
using Akasa.Data;
using AkasaYogaStudioAPI.Middleware;
using AkasaYogaStudioAPI.MigrationsInitContext;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using NLog.Extensions.Logging;
using NLog.Web;
using Swashbuckle.AspNetCore.Swagger;

namespace AkasaYogaStudioAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            var connString = Configuration.GetConnectionString("DefaultConnection");
            var pathToDoc = Configuration["Swagger:FileName"];
            var version = Configuration["Swagger:Version"];

            var swaggerInfo = new Info
            {
                Title = Configuration["Swagger:Title"],
                Version = version,
                Description = Configuration["Swagger:Description"],
                TermsOfService = Configuration["Swagger:TermsOfService"]
            };

            services.AddDbContext<AkasaDBContext>(x => x.UseMySql(connString,
                o => o.MigrationsAssembly("AkasaYogaStudioAPI")));

            services.AddMvc(options =>
                {
                    options.Filters.Add(new ValidateModelAttribute());
                })
                .AddFluentValidation(fvc =>
                    fvc.RegisterValidatorsFromAssemblyContaining<Startup>()); 

            services.AddMemoryCache();

            services.AddAkasaMappingService();

            services.AddAkasaServices();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(version, swaggerInfo);

                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, pathToDoc);
                options.IncludeXmlComments(filePath);
                options.DescribeAllEnumsAsStrings();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, AkasaDBContext context)
        {
            app.ConfigureAkasaLogging(env, loggerFactory, Configuration.GetSection("Logging"));

            app.UseStaticFiles();

            app.UseMvc(); 

            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value);
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
            });

            DbInitializer.Initialize(context);
        }
    }
}
