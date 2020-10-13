using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kidregs.Migrations
{
    public partial class Setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KidsInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KidName = table.Column<string>(maxLength: 50, nullable: true),
                    KidIdCard = table.Column<string>(nullable: true),
                    gender = table.Column<string>(maxLength: 50, nullable: true),
                    KidNation = table.Column<int>(nullable: false),
                    KidHouseholdType = table.Column<string>(nullable: true),
                    KidRegRes = table.Column<string>(nullable: true),
                    KidDomicile = table.Column<string>(nullable: true),
                    KidBirth = table.Column<DateTime>(type: "date", nullable: true),
                    DadName = table.Column<string>(maxLength: 50, nullable: true),
                    DadWorkRes = table.Column<string>(nullable: true),
                    DadPhone = table.Column<string>(nullable: true),
                    DadIdCard = table.Column<string>(nullable: true),
                    MunName = table.Column<string>(maxLength: 50, nullable: true),
                    MunWorkRes = table.Column<string>(nullable: true),
                    MunPhone = table.Column<string>(nullable: true),
                    MunIdCard = table.Column<string>(nullable: true),
                    HomeAddres = table.Column<string>(nullable: true),
                    GrandName = table.Column<string>(nullable: true),
                    GrandWorkRes = table.Column<string>(nullable: true),
                    GrandPhone = table.Column<string>(nullable: true),
                    LikeAsk = table.Column<string>(nullable: true),
                    IndieEat = table.Column<string>(nullable: true),
                    LikePlay = table.Column<string>(nullable: true),
                    LikeRead = table.Column<string>(nullable: true),
                    Nap = table.Column<string>(nullable: true),
                    Accommodating = table.Column<string>(nullable: true),
                    WashHand = table.Column<int>(nullable: false),
                    Dress = table.Column<string>(nullable: true),
                    Defecate = table.Column<string>(nullable: true),
                    BrushTeeth = table.Column<string>(nullable: true),
                    Urinate = table.Column<string>(nullable: true),
                    GetUpTime = table.Column<DateTime>(nullable: false),
                    SleepTime = table.Column<DateTime>(nullable: false),
                    LikeFood = table.Column<string>(nullable: true),
                    Case = table.Column<string>(nullable: true),
                    MealLength = table.Column<string>(nullable: true),
                    SensibiligenFood = table.Column<string>(nullable: true),
                    Fever = table.Column<string>(nullable: true),
                    SensibiligenMedicine = table.Column<string>(nullable: true),
                    Hobbies = table.Column<string>(nullable: true),
                    Others = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "NationList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KidsInfo");

            migrationBuilder.DropTable(
                name: "NationList");
        }
    }
}
