using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class ChangeRelationshipBetweenRaceParticipantAndRaceParticipantBets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RaceParticipantsBets_RaceParticipantId",
                table: "RaceParticipantsBets");

            migrationBuilder.CreateIndex(
                name: "IX_RaceParticipantsBets_RaceParticipantId",
                table: "RaceParticipantsBets",
                column: "RaceParticipantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RaceParticipantsBets_RaceParticipantId",
                table: "RaceParticipantsBets");

            migrationBuilder.CreateIndex(
                name: "IX_RaceParticipantsBets_RaceParticipantId",
                table: "RaceParticipantsBets",
                column: "RaceParticipantId",
                unique: true);
        }
    }
}
