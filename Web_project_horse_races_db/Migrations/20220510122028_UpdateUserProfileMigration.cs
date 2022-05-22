using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class UpdateUserProfileMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserMoneyBalance",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "UsersBetProfiles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INT", nullable: false),
                    UserMoneyBalance = table.Column<decimal>(type: "money", nullable: false),
                    UserBetCount = table.Column<int>(type: "INT", nullable: false),
                    UserWinBetCount = table.Column<int>(type: "INT", nullable: false),
                    UserLooseBetCount = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersBetProfiles", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UsersBetProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersBetProfiles");

            migrationBuilder.AddColumn<decimal>(
                name: "UserMoneyBalance",
                table: "Users",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
