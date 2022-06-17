using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class ChangeRaceStatusType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<string>(
                name: "RaceStatus",
                table: "Races",
                type: "varchar(30)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookmakerBets_Bookmakers_UserId",
                table: "BookmakerBets");

            migrationBuilder.RenameColumn(
                name: "BookmakerMoneyBalance",
                table: "Bookmakers",
                newName: "UserMoneyBalance");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BookmakerBets",
                newName: "BookmakerId");

            migrationBuilder.RenameIndex(
                name: "IX_BookmakerBets_UserId",
                table: "BookmakerBets",
                newName: "IX_BookmakerBets_BookmakerId");

            migrationBuilder.AlterColumn<int>(
                name: "RaceStatus",
                table: "Races",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)");

            migrationBuilder.AddForeignKey(
                name: "FK_BookmakerBets_Bookmakers_BookmakerId",
                table: "BookmakerBets",
                column: "BookmakerId",
                principalTable: "Bookmakers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
