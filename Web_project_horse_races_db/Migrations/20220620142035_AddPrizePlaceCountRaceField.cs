using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class AddPrizePlaceCountRaceField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrizePlaceCount",
                table: "Races",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrizePlaceCount",
                table: "Races");
        }
    }
}
