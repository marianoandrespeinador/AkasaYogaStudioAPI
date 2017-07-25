using System;
using System.Collections.Generic;
using System.Linq;
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
            if (!context.User.Any())
            {
                context.User.Add(new User
                {
                    Name = "Nano",
                    FacebookID = String.Empty,
                    Email = "nanopp@gmail.com",
                    LstUserXRole = new List<UserXRole>() { new UserXRole
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

            if (!context.PaymentModality.Any())
            {
                context.PaymentModality.AddRange(
                    new PaymentModality
                    {
                        Cost = 6000,
                        LessonQuantityAvailable = 1,
                        LessonAvailabilityPeriod = new TimeSpan(1, 0, 0, 0)
                    },
                    new PaymentModality
                    {
                        Cost = 16000,
                        LessonQuantityAvailable = 4,
                        LessonAvailabilityPeriod = new TimeSpan(30, 0, 0, 0)
                    },
                    new PaymentModality
                    {
                        Cost = 28000,
                        LessonQuantityAvailable = 8,
                        LessonAvailabilityPeriod = new TimeSpan(60, 0, 0, 0)
                    },
                    new PaymentModality
                    {
                        Cost = 48000,
                        LessonQuantityAvailable = 16,
                        LessonAvailabilityPeriod = new TimeSpan(90, 0, 0, 0)
                    });
            }
        }

    }
}
