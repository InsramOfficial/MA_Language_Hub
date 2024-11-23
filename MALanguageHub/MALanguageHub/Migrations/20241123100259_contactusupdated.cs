using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MALanguageHub.Migrations
{
    public partial class contactusupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "tbl_contactus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "tbl_contactus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TikTok",
                table: "tbl_contactus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "tbl_contactus");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "tbl_contactus");

            migrationBuilder.DropColumn(
                name: "TikTok",
                table: "tbl_contactus");
        }
    }
}
