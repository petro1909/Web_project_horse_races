using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class ChangeDeleteAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceBets_RaceParticipants_RaceParticipantId",
                table: "RaceBets");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceBets_RaceParticipants_RaceParticipantId",
                table: "RaceBets",
                column: "RaceParticipantId",
                principalTable: "RaceParticipants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceBets_RaceParticipants_RaceParticipantId",
                table: "RaceBets");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceBets_RaceParticipants_RaceParticipantId",
                table: "RaceBets",
                column: "RaceParticipantId",
                principalTable: "RaceParticipants",
                principalColumn: "Id");
        }
    }
}
