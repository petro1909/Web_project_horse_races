using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class ReworkDBStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookmakerBets_RaceParticipants_RaceParticipantId",
                table: "BookmakerBets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBets_UserBetType_UserBetTypeId",
                table: "UserBets");

            migrationBuilder.DropTable(
                name: "UserBetType");

            migrationBuilder.DropIndex(
                name: "IX_UserBets_UserBetTypeId",
                table: "UserBets");

            migrationBuilder.DropColumn(
                name: "UserBetTypeId",
                table: "UserBets");
            
            migrationBuilder.CreateIndex(
                name: "IX_BookmakerBets_RaceParticipantId",
                table: "BookmakerBets",
                column: "RaceParticipantId");

            migrationBuilder.RenameColumn(
                name: "RaceParticipantId",
                table: "BookmakerBets",
                newName: "RaceParticipantBetId");
            


            migrationBuilder.RenameIndex(
                name: "IX_BookmakerBets_RaceParticipantId",
                table: "BookmakerBets",
                newName: "IX_BookmakerBets_RaceParticipantBetId");

            migrationBuilder.CreateTable(
                name: "BetType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetType", x => x.Id);
                    table.UniqueConstraint("AK_BetType_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "RaceParticipantsBets",
                columns: table => new
                {
                    RaceParticipantBetId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceParticipantId = table.Column<int>(type: "INT", nullable: false),
                    RaceBetType = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceParticipantsBets", x => x.RaceParticipantBetId);
                    table.ForeignKey(
                        name: "FK_RaceParticipantsBets_BetType_RaceBetType",
                        column: x => x.RaceBetType,
                        principalTable: "BetType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceParticipantsBets_RaceParticipants_RaceParticipantId",
                        column: x => x.RaceParticipantId,
                        principalTable: "RaceParticipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceParticipantsBets_RaceBetType",
                table: "RaceParticipantsBets",
                column: "RaceBetType");

            migrationBuilder.CreateIndex(
                name: "IX_RaceParticipantsBets_RaceParticipantId",
                table: "RaceParticipantsBets",
                column: "RaceParticipantId");

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

            migrationBuilder.DropTable(
                name: "RaceParticipantsBets");

            migrationBuilder.DropTable(
                name: "BetType");

            migrationBuilder.RenameColumn(
                name: "RaceParticipantBetId",
                table: "BookmakerBets",
                newName: "RaceParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_BookmakerBets_RaceParticipantBetId",
                table: "BookmakerBets",
                newName: "IX_BookmakerBets_RaceParticipantId");

            migrationBuilder.AddColumn<int>(
                name: "UserBetTypeId",
                table: "UserBets",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserBetType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBetType", x => x.Id);
                    table.UniqueConstraint("AK_UserBetType_Name", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBets_UserBetTypeId",
                table: "UserBets",
                column: "UserBetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookmakerBets_RaceParticipants_RaceParticipantId",
                table: "BookmakerBets",
                column: "RaceParticipantId",
                principalTable: "RaceParticipants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBets_UserBetType_UserBetTypeId",
                table: "UserBets",
                column: "UserBetTypeId",
                principalTable: "UserBetType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
