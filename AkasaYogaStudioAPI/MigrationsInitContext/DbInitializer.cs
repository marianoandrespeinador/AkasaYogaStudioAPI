using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akasa.Data;
using Akasa.Model;

namespace AkasaYogaStudioAPI.MigrationsInitContext
{
    public static class DbInitializer
    {
        public static void Initialize(AkasaDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.User.Any())
            {
                return; // DB has been seeded
            }

            context.User.Add(new User
            {
                Name = "Nano",
                FacebookID = String.Empty,
                Email = "nanopp@gmail.com",
                LstUserRole = new List<UserRole>() { new UserRole
                {
                   VKRole = 2
                } }
            });

            context.SaveChanges();
        }

    }
}
