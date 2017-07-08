using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AkasaYogaStudioAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentModality",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Cost = table.Column<decimal>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    LessonAvailabilityPeriod = table.Column<TimeSpan>(nullable: false),
                    LessonQuantityAvailable = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentModality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    FacebookID = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonDay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    DateFixed = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    LessonId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonDay_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonRecurrent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Friday = table.Column<bool>(nullable: false),
                    LessonId = table.Column<int>(nullable: false),
                    Monday = table.Column<bool>(nullable: false),
                    Saturday = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Sunday = table.Column<bool>(nullable: false),
                    Thursday = table.Column<bool>(nullable: false),
                    Tuesday = table.Column<bool>(nullable: false),
                    Wednesday = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonRecurrent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonRecurrent_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInjury",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    InjuryDescription = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInjury", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInjury_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPayment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    PaymentModalityId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    TotalAmountPayed = table.Column<decimal>(nullable: false),
                    TotalAmountToPay = table.Column<decimal>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPayment_PaymentModality_PaymentModalityId",
                        column: x => x.PaymentModalityId,
                        principalTable: "PaymentModality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPayment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserXRole",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    VKRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserXRole", x => new { x.UserId, x.VKRole });
                    table.ForeignKey(
                        name: "FK_UserXRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonItsOn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    DateItsOn = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    LessonDayId = table.Column<int>(nullable: true),
                    LessonRecurrentId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonItsOn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonItsOn_LessonDay_LessonDayId",
                        column: x => x.LessonDayId,
                        principalTable: "LessonDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonItsOn_LessonRecurrent_LessonRecurrentId",
                        column: x => x.LessonRecurrentId,
                        principalTable: "LessonRecurrent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LessonRecurrentException",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    DateException = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    LessonRecurrentId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonRecurrentException", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonRecurrentException_LessonRecurrent_LessonRecurrentId",
                        column: x => x.LessonRecurrentId,
                        principalTable: "LessonRecurrent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPaymentDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    AmountPayed = table.Column<decimal>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    UserPaymentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPaymentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPaymentDetail_UserPayment_UserPaymentId",
                        column: x => x.UserPaymentId,
                        principalTable: "UserPayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonItsOnXUser",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LessonItsOnId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonItsOnXUser", x => new { x.UserId, x.LessonItsOnId });
                    table.ForeignKey(
                        name: "FK_LessonItsOnXUser_LessonItsOn_LessonItsOnId",
                        column: x => x.LessonItsOnId,
                        principalTable: "LessonItsOn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonItsOnXUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonDay_LessonId",
                table: "LessonDay",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonItsOn_LessonDayId",
                table: "LessonItsOn",
                column: "LessonDayId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonItsOn_LessonRecurrentId",
                table: "LessonItsOn",
                column: "LessonRecurrentId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonItsOnXUser_LessonItsOnId",
                table: "LessonItsOnXUser",
                column: "LessonItsOnId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonRecurrent_LessonId",
                table: "LessonRecurrent",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonRecurrentException_LessonRecurrentId",
                table: "LessonRecurrentException",
                column: "LessonRecurrentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInjury_UserId",
                table: "UserInjury",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPayment_PaymentModalityId",
                table: "UserPayment",
                column: "PaymentModalityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPayment_UserId",
                table: "UserPayment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPaymentDetail_UserPaymentId",
                table: "UserPaymentDetail",
                column: "UserPaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonItsOnXUser");

            migrationBuilder.DropTable(
                name: "LessonRecurrentException");

            migrationBuilder.DropTable(
                name: "UserInjury");

            migrationBuilder.DropTable(
                name: "UserPaymentDetail");

            migrationBuilder.DropTable(
                name: "UserXRole");

            migrationBuilder.DropTable(
                name: "LessonItsOn");

            migrationBuilder.DropTable(
                name: "UserPayment");

            migrationBuilder.DropTable(
                name: "LessonDay");

            migrationBuilder.DropTable(
                name: "LessonRecurrent");

            migrationBuilder.DropTable(
                name: "PaymentModality");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Lesson");
        }
    }
}
