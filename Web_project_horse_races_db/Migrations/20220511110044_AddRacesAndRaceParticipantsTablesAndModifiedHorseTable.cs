using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class AddRacesAndRaceParticipantsTablesAndModifiedHorseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    RaceId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceDate = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.RaceId);
                });

            migrationBuilder.CreateTable(
                name: "RaceParticipants",
                columns: table => new
                {
                    RaceId = table.Column<int>(type: "INT", nullable: false),
                    HorseId = table.Column<int>(type: "INT", nullable: false),
                    RaceParticipantNumber = table.Column<byte>(type: "TINYINT", nullable: false),
                    RaceParticipantPosition = table.Column<byte>(type: "TINYINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceParticipants", x => new { x.RaceId, x.HorseId });
                    table.ForeignKey(
                        name: "FK_RaceParticipants_Horses_HorseId",
                        column: x => x.HorseId,
                        principalTable: "Horses",
                        principalColumn: "HorseId");
                    table.ForeignKey(
                        name: "FK_RaceParticipants_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "RaceId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceParticipants_HorseId",
                table: "RaceParticipants",
                column: "HorseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaceParticipants");

            migrationBuilder.DropTable(
                name: "Races");
        }
    }
}
