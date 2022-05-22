using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class UpdateUserProfileMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersBetProfiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersBetProfiles",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserBetCount = table.Column<int>(type: "INT", nullable: false),
                    UserLooseBetCount = table.Column<int>(type: "INT", nullable: false),
                    UserMoneyBalance = table.Column<decimal>(type: "money", nullable: false),
                    UserId = table.Column<int>(type: "INT", nullable: false),
                    UserWinBetCount = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersBetProfiles", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_UsersBetProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersBetProfiles_UserId",
                table: "UsersBetProfiles",
                column: "UserId",
                unique: true);
        }
    }
}
