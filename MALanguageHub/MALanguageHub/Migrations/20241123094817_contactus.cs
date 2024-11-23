using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MALanguageHub.Migrations
{
    public partial class contactus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_contactus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatsappNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_contactus", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_contactus");
        }
    }
}
