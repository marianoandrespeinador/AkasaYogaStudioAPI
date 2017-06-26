using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Akasa.Data.DBGen
{
    class Program
    {
        private static IConfigurationRoot Configuration { get; set; }

        /// <summary>
        /// Load the json configuration files (connection string)
        /// </summary>
        private static void AddConfigurationSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .AddJsonFile("appsettings.local.overrides.json", true);

            Configuration = builder.Build();
        }

        static void Main(string[] args)
        {
            AddConfigurationSettings();

            // Initialize db context provider
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            Console.WriteLine("Launching dangerous rockets!!");
            
            Console.WriteLine($"Connection string: {connectionString}");
            Console.WriteLine();
            Console.WriteLine("Opciones:");
            Console.WriteLine();
            Console.WriteLine("a) Aplicar migraciones e insertar registros.");
            Console.WriteLine("b) BORRAR y re-crear la BD.");
            Console.WriteLine("c) Solo insertar registros.");
            Console.WriteLine("d) Solo insertar TEST Data.");
            Console.WriteLine("e) BORRAR y re-crear la BD con TEST Data.");
            Console.WriteLine();
            Console.WriteLine("O cualquier otra tecla para salir.");

            var migrate = false;
            var create = false;
            var insert = false;
            var insertTEST = false;

            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.A:
                    migrate = true;
                    insert = true;
                    break;
                case ConsoleKey.B:
                    create = true;
                    //insert = true;
                    break;
                case ConsoleKey.C:
                    insert = true;
                    break;
                case ConsoleKey.D:
                    insertTEST = true;
                    break;
                case ConsoleKey.E:
                    create = true;
                    insert = true;
                    insertTEST = true;
                    break;
                default: return;
            }

            Console.WriteLine();

            var optionsBuilder = new DbContextOptionsBuilder<AkasaDBContext>();
            optionsBuilder.UseMySql(connectionString);

            using (var context = new AkasaDBContext(optionsBuilder.Options))
            {
                if (migrate)
                {
                    Console.WriteLine("Migrating...");
                    context.Database.Migrate();
                }

                if (create)
                {
                    // Create database
                    Console.WriteLine("Wiping out old beliefs...");
                    context.Database.EnsureDeleted();

                    Console.WriteLine("Doing karma yoga...");
                    context.Database.EnsureCreated();
                }

                if (insert)
                {
                    // Insertar datos
                    Console.WriteLine("Inserting base data (currently empty BTW)...");
                    DbInitializer.SeedData(context);
                }

                if (insertTEST)
                {
                    // Insertar datos TESTING
                    throw new NotImplementedException();
                }
            }

            Console.ReadKey();
        }
    }
}