using Microsoft.EntityFrameworkCore.Migrations;

namespace Kidregs.Migrations
{
    public partial class recaptcha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "reCAPTCHASwitch",
                table: "System",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "reCAPTCHA_ServerUrl",
                table: "System",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reCAPTCHASwitch",
                table: "System");

            migrationBuilder.DropColumn(
                name: "reCAPTCHA_ServerUrl",
                table: "System");
        }
    }
}
