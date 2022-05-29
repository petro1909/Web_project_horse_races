using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class updateBookmakers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Bookmakers_UserEmail",
                table: "Bookmakers");

            migrationBuilder.RenameColumn(
                name: "UserPassword",
                table: "Bookmakers",
                newName: "BookmakerPassword");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Bookmakers",
                newName: "BookmakerName");

            migrationBuilder.RenameColumn(
                name: "UserMoneyBalance",
                table: "Bookmakers",
                newName: "BookmakerMoneyBalance");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Bookmakers",
                newName: "BookmakerEmail");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bookmakers",
                newName: "BookmakerId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Bookmakers_BookmakerEmail",
                table: "Bookmakers",
                column: "BookmakerEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_BookmakerBets_RaceParticipantsBets_RaceParticipantBetId",
                table: "BookmakerBets",
                column: "RaceParticipantBetId",
                principalTable: "RaceParticipantsBets",
                principalColumn: "RaceParticipantBetId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookmakerBets_RaceParticipantsBets_RaceParticipantBetId",
                table: "BookmakerBets");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Bookmakers_BookmakerEmail",
                table: "Bookmakers");

            migrationBuilder.RenameColumn(
                name: "BookmakerPassword",
                table: "Bookmakers",
                newName: "UserPassword");

            migrationBuilder.RenameColumn(
                name: "BookmakerName",
                table: "Bookmakers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "BookmakerMoneyBalance",
                table: "Bookmakers",
                newName: "UserMoneyBalance");

            migrationBuilder.RenameColumn(
                name: "BookmakerEmail",
                table: "Bookmakers",
                newName: "UserEmail");

            migrationBuilder.RenameColumn(
                name: "BookmakerId",
                table: "Bookmakers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RaceParticipantBetId",
                table: "BookmakerBets",
                newName: "RaceParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_BookmakerBets_RaceParticipantBetId",
                table: "BookmakerBets",
                newName: "IX_BookmakerBets_RaceParticipantId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Bookmakers_UserEmail",
                table: "Bookmakers",
                column: "UserEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_BookmakerBets_RaceParticipantsBets_RaceParticipantId",
                table: "BookmakerBets",
                column: "RaceParticipantId",
                principalTable: "RaceParticipantsBets",
                principalColumn: "RaceParticipanrBetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
