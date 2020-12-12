using Microsoft.EntityFrameworkCore.Migrations;

namespace NETD3202_Lab5Communication_RyanClayson.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerDetails",
                columns: table => new
                {
                    playerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    playerAge = table.Column<int>(nullable: false),
                    playerHeight = table.Column<string>(nullable: true),
                    playerWeight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerDetails", x => x.playerID);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    playerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    yearDrafted = table.Column<int>(nullable: false),
                    teamName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.playerID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerDetails");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
