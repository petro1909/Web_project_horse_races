using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class UpdateUserProfileMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersBetProfiles",
                table: "UsersBetProfiles");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "UsersBetProfiles",
                type: "INT",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersBetProfiles",
                table: "UsersBetProfiles",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersBetProfiles_UserId",
                table: "UsersBetProfiles",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersBetProfiles",
                table: "UsersBetProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UsersBetProfiles_UserId",
                table: "UsersBetProfiles");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "UsersBetProfiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersBetProfiles",
                table: "UsersBetProfiles",
                column: "UserId");
        }
    }
}
