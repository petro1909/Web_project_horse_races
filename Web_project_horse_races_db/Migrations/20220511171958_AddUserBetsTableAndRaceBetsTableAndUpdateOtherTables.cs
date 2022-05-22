using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class AddUserBetsTableAndRaceBetsTableAndUpdateOtherTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RaceParticipants",
                table: "RaceParticipants");

            migrationBuilder.AddColumn<int>(
                name: "RaceStatus",
                table: "Races",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RaceParticipants",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaceParticipants",
                table: "RaceParticipants",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RaceBets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceId = table.Column<int>(type: "INT", nullable: false),
                    RaceParticipantId = table.Column<int>(type: "INT", nullable: false),
                    RaceBetCoefficient = table.Column<double>(type: "float", nullable: false),
                    RaceBetTotalSum = table.Column<decimal>(type: "money", nullable: false),
                    RaceBetUserBetCount = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceBets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceBets_RaceParticipants_RaceParticipantId",
                        column: x => x.RaceParticipantId,
                        principalTable: "RaceParticipants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RaceBets_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "RaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBet",
                columns: table => new
                {
                    UserBetProfileId = table.Column<int>(type: "INT", nullable: false),
                    UserBetRaceBetId = table.Column<int>(type: "INT", nullable: false),
                    UserBetSum = table.Column<decimal>(type: "money", nullable: false),
                    UserBetCoefficient = table.Column<double>(type: "float", nullable: false),
                    UserBetPossibleWin = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBet", x => new { x.UserBetProfileId, x.UserBetRaceBetId });
                    table.ForeignKey(
                        name: "FK_UserBet_RaceBets_UserBetRaceBetId",
                        column: x => x.UserBetRaceBetId,
                        principalTable: "RaceBets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBet_UsersBetProfiles_UserBetProfileId",
                        column: x => x.UserBetProfileId,
                        principalTable: "UsersBetProfiles",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceParticipants_RaceId",
                table: "RaceParticipants",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceBets_RaceId",
                table: "RaceBets",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceBets_RaceParticipantId",
                table: "RaceBets",
                column: "RaceParticipantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBet_UserBetRaceBetId",
                table: "UserBet",
                column: "UserBetRaceBetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBet");

            migrationBuilder.DropTable(
                name: "RaceBets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RaceParticipants",
                table: "RaceParticipants");

            migrationBuilder.DropIndex(
                name: "IX_RaceParticipants_RaceId",
                table: "RaceParticipants");

            migrationBuilder.DropColumn(
                name: "RaceStatus",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RaceParticipants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaceParticipants",
                table: "RaceParticipants",
                columns: new[] { "RaceId", "HorseId" });
        }
    }
}
