using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class ChangeLinksBetweenRaceParticipantAndRaceBet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBets_RaceBets_UserBetRaceBetId",
                table: "UserBets");

            migrationBuilder.DropTable(
                name: "RaceBets");

            migrationBuilder.RenameColumn(
                name: "UserBetRaceBetId",
                table: "UserBets",
                newName: "UserBetRaceParticipantBetId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBets_UserBetRaceBetId",
                table: "UserBets",
                newName: "IX_UserBets_UserBetRaceParticipantBetId");

            migrationBuilder.CreateTable(
                name: "RaceParticipantsBets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceParticipantId = table.Column<int>(type: "INT", nullable: false),
                    RaceBetCoefficient = table.Column<double>(type: "float", nullable: false),
                    RaceBetTotalSum = table.Column<decimal>(type: "money", nullable: false),
                    RaceBetUserBetCount = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceParticipantsBets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceParticipantsBets_RaceParticipants_RaceParticipantId",
                        column: x => x.RaceParticipantId,
                        principalTable: "RaceParticipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceParticipantsBets_RaceParticipantId",
                table: "RaceParticipantsBets",
                column: "RaceParticipantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBets_RaceParticipantsBets_UserBetRaceParticipantBetId",
                table: "UserBets",
                column: "UserBetRaceParticipantBetId",
                principalTable: "RaceParticipantsBets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBets_RaceParticipantsBets_UserBetRaceParticipantBetId",
                table: "UserBets");

            migrationBuilder.DropTable(
                name: "RaceParticipantsBets");

            migrationBuilder.RenameColumn(
                name: "UserBetRaceParticipantBetId",
                table: "UserBets",
                newName: "UserBetRaceBetId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBets_UserBetRaceParticipantBetId",
                table: "UserBets",
                newName: "IX_UserBets_UserBetRaceBetId");

            migrationBuilder.CreateTable(
                name: "RaceBets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceBetCoefficient = table.Column<double>(type: "float", nullable: false),
                    RaceId = table.Column<int>(type: "INT", nullable: false),
                    RaceParticipantId = table.Column<int>(type: "INT", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceBets_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "RaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceBets_RaceId",
                table: "RaceBets",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceBets_RaceParticipantId",
                table: "RaceBets",
                column: "RaceParticipantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBets_RaceBets_UserBetRaceBetId",
                table: "UserBets",
                column: "UserBetRaceBetId",
                principalTable: "RaceBets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
