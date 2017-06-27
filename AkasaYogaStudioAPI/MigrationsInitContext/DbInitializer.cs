using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akasa.Data;
using Akasa.Model;
using Akasa.Model.VirtualKeys;

namespace AkasaYogaStudioAPI.MigrationsInitContext
{
    public static class DbInitializer
    {
        public static void Initialize(AkasaDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (!context.User.Any())
            {
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

            if (!context.Lesson.Any())
            {
                context.Lesson.Add(new Lesson
                {
                    Name = "Yoga Martes",
                    Description = "Aca la descripcion de la clase",
                    LstLessonCost = new List<LessonCost>
                    {
                        new LessonCost {Price = 5000, VKPaymentType = (int) PaymentType.Once},
                        new LessonCost {Price = 16000, VKPaymentType = (int) PaymentType.Monthly}
                    },
                    LstLessonRecurrent = new List<LessonRecurrent>
                    {
                        new LessonRecurrent
                        {
                            Tuesday = true
                        }
                    }
                });

                context.SaveChanges();
            }

        }

    }
}
