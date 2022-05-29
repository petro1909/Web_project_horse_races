using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class AddBetType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RaceBetTypeId",
                table: "RaceParticipantsBets",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RaceBetType",
                columns: table => new
                {
                    RaceBetTypeId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceBetTypeName = table.Column<string>(name: "RaceBetTypeName", type: "varchar(25)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceBetType", x => x.RaceBetTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceParticipantsBets_RaceBetTypeId",
                table: "RaceParticipantsBets",
                column: "RaceBetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceParticipantsBets_RaceBetType_RaceBetTypeId",
                table: "RaceParticipantsBets",
                column: "RaceBetTypeId",
                principalTable: "RaceBetType",
                principalColumn: "RaceBetTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceParticipantsBets_RaceBetType_RaceBetTypeId",
                table: "RaceParticipantsBets");

            migrationBuilder.DropTable(
                name: "RaceBetType");

            migrationBuilder.DropIndex(
                name: "IX_RaceParticipantsBets_RaceBetTypeId",
                table: "RaceParticipantsBets");

            migrationBuilder.DropColumn(
                name: "RaceBetTypeId",
                table: "RaceParticipantsBets");

            migrationBuilder.RenameColumn(
                name: "RaceParticipanrBetId",
                table: "RaceParticipantsBets",
                newName: "Id");
        }
    }
}
