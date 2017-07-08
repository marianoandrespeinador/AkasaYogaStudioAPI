using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Akasa.Data;

namespace AkasaYogaStudioAPI.Migrations
{
    [DbContext(typeof(AkasaDBContext))]
    partial class AkasaDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Akasa.Model.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("Akasa.Model.LessonDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateFixed");

                    b.Property<DateTime?>("EndDate");

                    b.Property<int>("LessonId");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("LessonDay");
                });

            modelBuilder.Entity("Akasa.Model.LessonItsOn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateItsOn");

                    b.Property<DateTime?>("EndDate");

                    b.Property<int?>("LessonDayId");

                    b.Property<int?>("LessonRecurrentId");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("LessonDayId");

                    b.HasIndex("LessonRecurrentId");

                    b.ToTable("LessonItsOn");
                });

            modelBuilder.Entity("Akasa.Model.LessonItsOnXUser", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("LessonItsOnId");

                    b.HasKey("UserId", "LessonItsOnId");

                    b.HasIndex("LessonItsOnId");

                    b.ToTable("LessonItsOnXUser");
                });

            modelBuilder.Entity("Akasa.Model.LessonRecurrent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("EndDate");

                    b.Property<bool>("Friday");

                    b.Property<int>("LessonId");

                    b.Property<bool>("Monday");

                    b.Property<bool>("Saturday");

                    b.Property<DateTime>("StartDate");

                    b.Property<bool>("Sunday");

                    b.Property<bool>("Thursday");

                    b.Property<bool>("Tuesday");

                    b.Property<bool>("Wednesday");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("LessonRecurrent");
                });

            modelBuilder.Entity("Akasa.Model.LessonRecurrentException", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateException");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EndDate");

                    b.Property<int>("LessonRecurrentId");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("LessonRecurrentId");

                    b.ToTable("LessonRecurrentException");
                });

            modelBuilder.Entity("Akasa.Model.PaymentModality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cost");

                    b.Property<DateTime?>("EndDate");

                    b.Property<TimeSpan>("LessonAvailabilityPeriod");

                    b.Property<int>("LessonQuantityAvailable");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("PaymentModality");
                });

            modelBuilder.Entity("Akasa.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Email");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("FacebookID");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("Password");

                    b.Property<string>("PasswordSalt");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Akasa.Model.UserInjury", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("InjuryDescription");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserInjury");
                });

            modelBuilder.Entity("Akasa.Model.UserPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("EndDate");

                    b.Property<int>("PaymentModalityId");

                    b.Property<DateTime>("StartDate");

                    b.Property<decimal>("TotalAmountPayed");

                    b.Property<decimal>("TotalAmountToPay");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PaymentModalityId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPayment");
                });

            modelBuilder.Entity("Akasa.Model.UserPaymentDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AmountPayed");

                    b.Property<DateTime?>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("UserPaymentId");

                    b.HasKey("Id");

                    b.HasIndex("UserPaymentId");

                    b.ToTable("UserPaymentDetail");
                });

            modelBuilder.Entity("Akasa.Model.UserXRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("VKRole");

                    b.HasKey("UserId", "VKRole");

                    b.ToTable("UserXRole");
                });

            modelBuilder.Entity("Akasa.Model.LessonDay", b =>
                {
                    b.HasOne("Akasa.Model.Lesson", "Lesson")
                        .WithMany("LstLessonDay")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Akasa.Model.LessonItsOn", b =>
                {
                    b.HasOne("Akasa.Model.LessonDay", "LessonDay")
                        .WithMany("LstLessonItsOn")
                        .HasForeignKey("LessonDayId");

                    b.HasOne("Akasa.Model.LessonRecurrent", "LessonRecurrent")
                        .WithMany("LstLessonItsOn")
                        .HasForeignKey("LessonRecurrentId");
                });

            modelBuilder.Entity("Akasa.Model.LessonItsOnXUser", b =>
                {
                    b.HasOne("Akasa.Model.LessonItsOn", "LessonItsOn")
                        .WithMany("LstLessonItsOnXUser")
                        .HasForeignKey("LessonItsOnId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Akasa.Model.User", "User")
                        .WithMany("LstLessonItsOnXUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Akasa.Model.LessonRecurrent", b =>
                {
                    b.HasOne("Akasa.Model.Lesson", "Lesson")
                        .WithMany("LstLessonRecurrent")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Akasa.Model.LessonRecurrentException", b =>
                {
                    b.HasOne("Akasa.Model.LessonRecurrent", "LessonRecurrent")
                        .WithMany("LstLessonRecurrentException")
                        .HasForeignKey("LessonRecurrentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Akasa.Model.UserInjury", b =>
                {
                    b.HasOne("Akasa.Model.User", "User")
                        .WithMany("LstUserInjury")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Akasa.Model.UserPayment", b =>
                {
                    b.HasOne("Akasa.Model.PaymentModality", "PaymentModality")
                        .WithMany()
                        .HasForeignKey("PaymentModalityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Akasa.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Akasa.Model.UserPaymentDetail", b =>
                {
                    b.HasOne("Akasa.Model.UserPayment", "UserPayment")
                        .WithMany()
                        .HasForeignKey("UserPaymentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Akasa.Model.UserXRole", b =>
                {
                    b.HasOne("Akasa.Model.User", "User")
                        .WithMany("LstUserXRole")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
