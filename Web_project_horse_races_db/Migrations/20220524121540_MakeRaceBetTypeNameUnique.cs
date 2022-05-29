using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class MakeRaceBetTypeNameUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RaceBetTypeName",
                table: "RaceBetType",
                type: "varchar(25)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(25)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RaceBetType_RaceBetTypeName",
                table: "RaceBetType",
                column: "RaceBetTypeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_RaceBetType_RaceBetTypeName",
                table: "RaceBetType");

            migrationBuilder.RenameColumn(
                name: "RaceParticipantBetId",
                table: "RaceParticipantsBets",
                newName: "RaceParticipanrBetId");

            migrationBuilder.AlterColumn<string>(
                name: "RaceBetTypeName",
                table: "RaceBetType",
                type: "varchar(25)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(25)");
        }
    }
}
