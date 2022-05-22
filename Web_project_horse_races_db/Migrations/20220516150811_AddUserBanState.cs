using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class AddUserBanState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBet_RaceBets_UserBetRaceBetId",
                table: "UserBet");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBet_UsersBetProfiles_UserBetProfileId",
                table: "UserBet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBet",
                table: "UserBet");

            migrationBuilder.RenameTable(
                name: "UserBet",
                newName: "UserBets");

            migrationBuilder.RenameIndex(
                name: "IX_UserBet_UserBetRaceBetId",
                table: "UserBets",
                newName: "IX_UserBets_UserBetRaceBetId");

            migrationBuilder.AddColumn<bool>(
                name: "BanState",
                table: "Users",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBets",
                table: "UserBets",
                columns: new[] { "UserBetProfileId", "UserBetRaceBetId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserBets_RaceBets_UserBetRaceBetId",
                table: "UserBets",
                column: "UserBetRaceBetId",
                principalTable: "RaceBets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBets_UsersBetProfiles_UserBetProfileId",
                table: "UserBets",
                column: "UserBetProfileId",
                principalTable: "UsersBetProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBets_RaceBets_UserBetRaceBetId",
                table: "UserBets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBets_UsersBetProfiles_UserBetProfileId",
                table: "UserBets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBets",
                table: "UserBets");

            migrationBuilder.DropColumn(
                name: "BanState",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "UserBets",
                newName: "UserBet");

            migrationBuilder.RenameIndex(
                name: "IX_UserBets_UserBetRaceBetId",
                table: "UserBet",
                newName: "IX_UserBet_UserBetRaceBetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBet",
                table: "UserBet",
                columns: new[] { "UserBetProfileId", "UserBetRaceBetId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserBet_RaceBets_UserBetRaceBetId",
                table: "UserBet",
                column: "UserBetRaceBetId",
                principalTable: "RaceBets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBet_UsersBetProfiles_UserBetProfileId",
                table: "UserBet",
                column: "UserBetProfileId",
                principalTable: "UsersBetProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
