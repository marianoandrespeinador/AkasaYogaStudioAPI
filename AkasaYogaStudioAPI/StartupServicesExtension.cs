using System.Linq;
using System.Reflection;
using Akasa.Services.Core;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;

namespace AkasaYogaStudioAPI
{
    public static class StartupServicesExtension
    {
        private const string ServicesAssemblyName = "Akasa.Services";

        /// <summary>
        ///     Uses Reflection for Dependency Injection of BusinessService.Web, BusinessService and Persistance layers service
        ///     classes.
        /// </summary>
        /// <param name="thisServiceCollection"></param>
        /// <param name="assemblyName">Name of the Assembly to Inspect.</param>
        /// <param name="typeService">Type of the Base Interface used for the services on the Assembly.</param>
        public static void AddAkasaServices(this IServiceCollection thisServiceCollection)
        {
            var typeService = typeof(IAmAService);
            var assemblyToGet = Assembly.Load(new AssemblyName(ServicesAssemblyName));

            foreach (var curInterfaceType in assemblyToGet.GetTypes()
                .Where(t => typeService.IsAssignableFrom(t)
                            && t.GetTypeInfo().IsInterface))
            {
                var curClassType =
                    assemblyToGet.GetTypes()
                        .FirstOrDefault(t => curInterfaceType.IsAssignableFrom(t) && t.GetTypeInfo().IsClass);

                if (curClassType == null)
                {
                    continue;
                }

                //Hay que usar "MakeGenericMethod" para invocar AddScoped. Sin embargo AddScoped es una extension ubicada en ServiceCollectionServiceExtensions...

                var addScopedMethod =
                    typeof(ServiceCollectionServiceExtensions)
                        .GetMethods(BindingFlags.Static | BindingFlags.Public)
                        .FirstOrDefault(mi => mi.Name.Equals("AddScoped")
                                              && mi.ContainsGenericParameters
                                              && (mi.GetParameters().Length == 1))
                        .MakeGenericMethod(curInterfaceType, curClassType);

                addScopedMethod.Invoke(null, new object[] { thisServiceCollection });
            }
        }

        /// <summary>
        ///     Add auto-mapping DI.
        /// </summary>
        /// <param name="thisServiceCollection"></param>
        /// <returns></returns>
        public static IServiceCollection AddAkasaMappingService(this IServiceCollection thisServiceCollection)
        {
            thisServiceCollection.AddAutoMapper();
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AkasaMapper());
            });
            return thisServiceCollection.AddSingleton(sp => mapperConfiguration.CreateMapper());
        }

        /// <summary>
        ///     Add logging service (NLog)
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        /// <param>
        ///     <name>thisServiceCollection</name>
        /// </param>
        /// <param name="loggingCongConfigurationSection"></param>
        /// <returns></returns>
        public static void ConfigureAkasaLogging(this IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IConfigurationSection loggingCongConfigurationSection)
        {
            loggerFactory.AddConsole(loggingCongConfigurationSection);
            loggerFactory.AddDebug();

            loggerFactory.AddNLog();

            app.AddNLogWeb();

            env.ConfigureNLog("NLog.config");
        }

    }
}
