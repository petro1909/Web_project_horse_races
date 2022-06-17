using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class ReworkDatabaseStructure2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookmakerBets_Bookmakers_BookmakerName",
                table: "BookmakerBets");

            migrationBuilder.DropTable(
                name: "BookmakerBetUserBet");

            migrationBuilder.DropIndex(
                name: "IX_BookmakerBets_BookmakerName",
                table: "BookmakerBets");

            migrationBuilder.DropColumn(
                name: "BookmakerName",
                table: "BookmakerBets");

            migrationBuilder.AddColumn<int>(
                name: "BookmakerBetId",
                table: "UserBets",
                type: "INT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookmakerRaceBetId",
                table: "UserBets",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookmakerRaceBetId",
                table: "BookmakerBets",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookmakerRaceBet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookmakerName = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    RaceId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookmakerRaceBet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookmakerRaceBet_Bookmakers_BookmakerName",
                        column: x => x.BookmakerName,
                        principalTable: "Bookmakers",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookmakerRaceBet_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "RaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBets_BookmakerBetId",
                table: "UserBets",
                column: "BookmakerBetId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBets_BookmakerRaceBetId",
                table: "UserBets",
                column: "BookmakerRaceBetId");

            migrationBuilder.CreateIndex(
                name: "IX_BookmakerBets_BookmakerRaceBetId",
                table: "BookmakerBets",
                column: "BookmakerRaceBetId");

            migrationBuilder.CreateIndex(
                name: "IX_BookmakerRaceBet_BookmakerName",
                table: "BookmakerRaceBet",
                column: "BookmakerName");

            migrationBuilder.CreateIndex(
                name: "IX_BookmakerRaceBet_RaceId",
                table: "BookmakerRaceBet",
                column: "RaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookmakerBets_BookmakerRaceBet_BookmakerRaceBetId",
                table: "BookmakerBets",
                column: "BookmakerRaceBetId",
                principalTable: "BookmakerRaceBet",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBets_BookmakerBets_BookmakerBetId",
                table: "UserBets",
                column: "BookmakerBetId",
                principalTable: "BookmakerBets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBets_BookmakerRaceBet_BookmakerRaceBetId",
                table: "UserBets",
                column: "BookmakerRaceBetId",
                principalTable: "BookmakerRaceBet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookmakerBets_BookmakerRaceBet_BookmakerRaceBetId",
                table: "BookmakerBets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBets_BookmakerBets_BookmakerBetId",
                table: "UserBets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBets_BookmakerRaceBet_BookmakerRaceBetId",
                table: "UserBets");

            migrationBuilder.DropTable(
                name: "BookmakerRaceBet");

            migrationBuilder.DropIndex(
                name: "IX_UserBets_BookmakerBetId",
                table: "UserBets");

            migrationBuilder.DropIndex(
                name: "IX_UserBets_BookmakerRaceBetId",
                table: "UserBets");

            migrationBuilder.DropIndex(
                name: "IX_BookmakerBets_BookmakerRaceBetId",
                table: "BookmakerBets");

            migrationBuilder.DropColumn(
                name: "BookmakerBetId",
                table: "UserBets");

            migrationBuilder.DropColumn(
                name: "BookmakerRaceBetId",
                table: "UserBets");

            migrationBuilder.DropColumn(
                name: "BookmakerRaceBetId",
                table: "BookmakerBets");

            migrationBuilder.AddColumn<string>(
                name: "BookmakerName",
                table: "BookmakerBets",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookmakerBetUserBet",
                columns: table => new
                {
                    BookmakerBetsId = table.Column<int>(type: "INT", nullable: false),
                    UserBetsId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookmakerBetUserBet", x => new { x.BookmakerBetsId, x.UserBetsId });
                    table.ForeignKey(
                        name: "FK_BookmakerBetUserBet_BookmakerBets_BookmakerBetsId",
                        column: x => x.BookmakerBetsId,
                        principalTable: "BookmakerBets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookmakerBetUserBet_UserBets_UserBetsId",
                        column: x => x.UserBetsId,
                        principalTable: "UserBets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookmakerBets_BookmakerName",
                table: "BookmakerBets",
                column: "BookmakerName");

            migrationBuilder.CreateIndex(
                name: "IX_BookmakerBetUserBet_UserBetsId",
                table: "BookmakerBetUserBet",
                column: "UserBetsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookmakerBets_Bookmakers_BookmakerName",
                table: "BookmakerBets",
                column: "BookmakerName",
                principalTable: "Bookmakers",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
