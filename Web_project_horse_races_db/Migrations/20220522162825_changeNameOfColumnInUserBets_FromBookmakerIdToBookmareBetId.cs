using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class changeNameOfColumnInUserBets_FromBookmakerIdToBookmareBetId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBets_BookmakerBets_BookmakerId",
                table: "UserBets");

            migrationBuilder.RenameColumn(
                name: "BookmakerId",
                table: "UserBets",
                newName: "BookmakerBetId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBets_BookmakerId",
                table: "UserBets",
                newName: "IX_UserBets_BookmakerBetId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBets_BookmakerBets_BookmakerBetId",
                table: "UserBets",
                column: "BookmakerBetId",
                principalTable: "BookmakerBets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBets_BookmakerBets_BookmakerBetId",
                table: "UserBets");

            migrationBuilder.RenameColumn(
                name: "BookmakerBetId",
                table: "UserBets",
                newName: "BookmakerId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBets_BookmakerBetId",
                table: "UserBets",
                newName: "IX_UserBets_BookmakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBets_BookmakerBets_BookmakerId",
                table: "UserBets",
                column: "BookmakerId",
                principalTable: "BookmakerBets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
