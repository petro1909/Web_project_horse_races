using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceParticipants_Races_RaceId",
                table: "RaceParticipants");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceParticipants_Races_RaceId",
                table: "RaceParticipants",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceParticipants_Races_RaceId",
                table: "RaceParticipants");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceParticipants_Races_RaceId",
                table: "RaceParticipants",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "RaceId");
        }
    }
}
