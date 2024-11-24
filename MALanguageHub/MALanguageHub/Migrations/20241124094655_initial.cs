using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MALanguageHub.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_aboutus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_aboutus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_contactus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatsappNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TikTok = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_contactus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllocatedTeacher = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_home",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_home", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_login", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ourprofessionals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatsAppLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstagramLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkedInLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ourprofessionals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoFavicon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_studentreviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Review = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_studentreviews", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tbl_aboutus",
                columns: new[] { "Id", "Description", "ImageName", "Title" },
                values: new object[] { 1, "Software Engineer", null, "Software" });

            migrationBuilder.InsertData(
                table: "tbl_contactus",
                columns: new[] { "Id", "Address1", "Address2", "EmailAddress1", "EmailAddress2", "Facebook", "Instagram", "PhoneNumber", "TikTok", "WhatsappNumber" },
                values: new object[] { 1, "Kotli Azad Kashmir", "Islamabad Pakistan", "info@gmail.com", "contact@malanguagehub.com", "https://www.facebook.com/muhammad.naseer039", "https://www.facebook.com/muhammad.naseer039", "923425464039", "https://www.facebook.com/muhammad.naseer039", "923425464039" });

            migrationBuilder.InsertData(
                table: "tbl_courses",
                columns: new[] { "Id", "AllocatedTeacher", "Description", "Duration", "ImageName", "StartingDate", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Description for Course 1", "2 Month", null, new DateTime(2024, 11, 24, 14, 46, 54, 698, DateTimeKind.Local).AddTicks(5678), "Available", "Course 1" },
                    { 2, 1, "Description for Course 2", "2 Month", null, new DateTime(2024, 11, 24, 14, 46, 54, 698, DateTimeKind.Local).AddTicks(5693), "Available", "Course 2" }
                });

            migrationBuilder.InsertData(
                table: "tbl_home",
                columns: new[] { "Id", "Description", "ImageName", "Title" },
                values: new object[,]
                {
                    { 1, "I am Software Engineer", null, "Software Engineer" },
                    { 2, "I am Civil Engineer", null, "Civil Engineer" }
                });

            migrationBuilder.InsertData(
                table: "tbl_login",
                columns: new[] { "Id", "FullName", "ImageName", "Password", "Username" },
                values: new object[] { 1, "Muhammad Naseer", null, "admin", "admin" });

            migrationBuilder.InsertData(
                table: "tbl_ourprofessionals",
                columns: new[] { "Id", "Description", "FacebookLink", "ImageName", "InstagramLink", "LinkedInLink", "Title", "WhatsAppLink" },
                values: new object[,]
                {
                    { 1, "I am a BS Computer Science student", "https://www.facebook.com/muhammad.naseer039", null, "https://www.facebook.com/muhammad.naseer039", "https://www.facebook.com/muhammad.naseer039", "Muhammad Naseer", "https://www.facebook.com/muhammad.naseer039" },
                    { 2, "I am a BS Information student", "https://www.facebook.com/muhammad.naseer039", null, "https://www.facebook.com/muhammad.naseer039", "https://www.facebook.com/muhammad.naseer039", "Muhammad Insram", "https://www.facebook.com/muhammad.naseer039" },
                    { 3, "I am a BS Mathematics student", "https://www.facebook.com/muhammad.naseer039", null, "https://www.facebook.com/muhammad.naseer039", "https://www.facebook.com/muhammad.naseer039", "Muhammad Sultan", "https://www.facebook.com/muhammad.naseer039" },
                    { 4, "I am a BS English student", "https://www.facebook.com/muhammad.naseer039", null, "https://www.facebook.com/muhammad.naseer039", "https://www.facebook.com/muhammad.naseer039", "Muhammad Ali", "https://www.facebook.com/muhammad.naseer039" }
                });

            migrationBuilder.InsertData(
                table: "tbl_settings",
                columns: new[] { "Id", "LogoFavicon", "Name" },
                values: new object[] { 1, null, "MALanguageHub" });

            migrationBuilder.InsertData(
                table: "tbl_studentreviews",
                columns: new[] { "Id", "Designation", "Name", "Review" },
                values: new object[,]
                {
                    { 1, "Student", "Insram", "Great learning experience!" },
                    { 2, "Student", "Naseer", "Great learning experience!" },
                    { 3, "Student", "Sultan", "Great learning experience!" },
                    { 4, "Student", "Ali", "Great learning experience!" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_aboutus");

            migrationBuilder.DropTable(
                name: "tbl_contactus");

            migrationBuilder.DropTable(
                name: "tbl_courses");

            migrationBuilder.DropTable(
                name: "tbl_home");

            migrationBuilder.DropTable(
                name: "tbl_login");

            migrationBuilder.DropTable(
                name: "tbl_ourprofessionals");

            migrationBuilder.DropTable(
                name: "tbl_settings");

            migrationBuilder.DropTable(
                name: "tbl_studentreviews");
        }
    }
}
