
using System.Reflection;
using Akasa.Data.Core;
using Akasa.Model;
using Microsoft.EntityFrameworkCore;

namespace Akasa.Data
{
    public class AkasaDBContext : DbContext
    {
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<LessonDay> LessonDay { get; set; }
        public virtual DbSet<LessonItsOn> LessonItsOn { get; set; }
        public virtual DbSet<LessonItsOnXUser> LessonItsOnXUser { get; set; }
        public virtual DbSet<LessonRecurrent> LessonRecurrent { get; set; }
        public virtual DbSet<LessonRecurrentException> LessonRecurrentException { get; set; }
        public virtual DbSet<PaymentModality> PaymentModality { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserInjury> UserInjury { get; set; }
        public virtual DbSet<UserPayment> UserPayment { get; set; }
        public virtual DbSet<UserPaymentDetail> UserPaymentDetail { get; set; }
        public virtual DbSet<UserXRole> UserRole { get; set; }

        public AkasaDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assemblyToGet = typeof(AkasaDBContext).GetTypeInfo().Assembly;
            EntityBuilderRegistrator.RegisterDataEntityToTableBuilders(modelBuilder, assemblyToGet);
        }
    }
}
