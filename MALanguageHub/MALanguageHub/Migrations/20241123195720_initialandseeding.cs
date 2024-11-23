using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MALanguageHub.Migrations
{
    public partial class initialandseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 1, 1, "Description for Course 1", "2 Month", null, new DateTime(2024, 11, 24, 0, 57, 20, 532, DateTimeKind.Local).AddTicks(4122), "Available", "Course 1" },
                    { 2, 1, "Description for Course 2", "2 Month", null, new DateTime(2024, 11, 24, 0, 57, 20, 532, DateTimeKind.Local).AddTicks(4133), "Available", "Course 2" }
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
            migrationBuilder.DeleteData(
                table: "tbl_aboutus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_contactus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbl_home",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_home",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbl_login",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_ourprofessionals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_ourprofessionals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbl_ourprofessionals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tbl_ourprofessionals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tbl_studentreviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_studentreviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbl_studentreviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tbl_studentreviews",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
