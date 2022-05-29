using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class AddUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "BaseUsers");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "BaseUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseUsers_RoleId",
                table: "BaseUsers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseUsers_UserRoles_RoleId",
                table: "BaseUsers",
                column: "RoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseUsers_UserRoles_RoleId",
                table: "BaseUsers");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_BaseUsers_RoleId",
                table: "BaseUsers");

            migrationBuilder.DropColumn(
                name: "UserMoneyBalance",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserMoneyBalance",
                table: "Bookmakers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "BaseUsers");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "BaseUsers",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UserMoneyBalance",
                table: "BaseUsers",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
