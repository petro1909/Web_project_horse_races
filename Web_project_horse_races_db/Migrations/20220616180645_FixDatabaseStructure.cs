using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class FixDatabaseStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBets_BookmakerBets_BookmakerBetId",
                table: "UserBets");

            migrationBuilder.DropIndex(
                name: "IX_UserBets_BookmakerBetId",
                table: "UserBets");

            migrationBuilder.DropColumn(
                name: "BookmakerBetId",
                table: "UserBets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookmakerBetId",
                table: "UserBets",
                type: "INT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBets_BookmakerBetId",
                table: "UserBets",
                column: "BookmakerBetId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBets_BookmakerBets_BookmakerBetId",
                table: "UserBets",
                column: "BookmakerBetId",
                principalTable: "BookmakerBets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
