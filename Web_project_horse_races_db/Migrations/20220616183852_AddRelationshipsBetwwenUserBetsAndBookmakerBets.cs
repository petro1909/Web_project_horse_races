using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class AddRelationshipsBetwwenUserBetsAndBookmakerBets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookmakerBetUserBet_UserBetsId",
                table: "BookmakerBetUserBet",
                column: "UserBetsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookmakerBetUserBet");
        }
    }
}
