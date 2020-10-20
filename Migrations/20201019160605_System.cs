using Microsoft.EntityFrameworkCore.Migrations;

namespace Kidregs.Migrations
{
    public partial class System : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "System",
                columns: table => new
                {
                    SiteName = table.Column<int>(nullable: false),
                    WelcomeMessage = table.Column<string>(nullable: true),
                    Domain = table.Column<string>(nullable: true),
                    reCAPTCHA_AppId = table.Column<string>(nullable: true),
                    reCAPTCHA_Secret = table.Column<string>(nullable: true),
                    RegSwitch = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "System");
        }
    }
}
