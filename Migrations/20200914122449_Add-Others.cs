using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kidregs.Migrations
{
    public partial class AddOthers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KidsInfo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    IdCard = table.Column<string>(maxLength: 50, nullable: true),
                    gender = table.Column<bool>(nullable: true),
                    birth = table.Column<DateTime>(type: "date", nullable: true),
                    father_name = table.Column<string>(maxLength: 50, nullable: true),
                    mother_name = table.Column<string>(maxLength: 50, nullable: true),
                    Others = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KidsInfo");
        }
    }
}
