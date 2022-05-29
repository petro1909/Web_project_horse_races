using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class ReworkUsersRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_UserEmail",
                table: "Users");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Bookmakers_BookmakerEmail",
                table: "Bookmakers");

            migrationBuilder.DropColumn(
                name: "BanState",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserPassword",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BanState",
                table: "Bookmakers");

            migrationBuilder.DropColumn(
                name: "BookmakerEmail",
                table: "Bookmakers");

            migrationBuilder.DropColumn(
                name: "BookmakerName",
                table: "Bookmakers");

            migrationBuilder.DropColumn(
                name: "BookmakerPassword",
                table: "Bookmakers");

            migrationBuilder.DropForeignKey(
                name: "FK_BookmakerBets_Bookmakers_BookmakerId",
                table: "BookmakerBets");

            migrationBuilder.RenameColumn(
                name: "BookmakerId",
                table: "BookmakerBets",
                newName: "UserId");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmakers",
                table: "Bookmakers");
            
            migrationBuilder.DropColumn(
                name: "BookmakerId",
                table: "Bookmakers");
            
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Users",
            //    table: "Users");
            
            //migrationBuilder.DropColumn(
            //    name: "UserId",
            //    table: "Users");

            //migrationBuilder.AddColumn<int>(
            //    name: "UserId",
            //    table: "Users",
            //    type: "INT",
            //    nullable: false);
            
            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Users",
            //    table: "Users",
            //    column : "UserId");

            

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Bookmakers",
                type: "INT",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmakers",
                table: "Bookmakers",
                column: "UserId");


            migrationBuilder.AddForeignKey(
                name: "FK_BookmakerBets_Bookmakers_UserId",
                table: "BookmakerBets",
                column: "UserId",
                principalTable: "Bookmakers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.CreateTable(
                name: "BaseUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    UserEmail = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    UserPassword = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    BanState = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    UserMoneyBalance = table.Column<decimal>(type: "money", nullable: false),
                    Role = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseUsers", x => x.UserId);
                    table.UniqueConstraint("AK_BaseUsers_UserEmail", x => x.UserEmail);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmakers_BaseUsers_UserId",
                table: "Bookmakers",
                column: "UserId",
                principalTable: "BaseUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_BaseUsers_UserId",
                table: "Users",
                column: "UserId",
                principalTable: "BaseUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmakers_BaseUsers_UserId",
                table: "Bookmakers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_BaseUsers_UserId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "BaseUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Bookmakers",
                newName: "BookmakerId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Users",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "BanState",
                table: "Users",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Users",
                type: "VARCHAR(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "UserMoneyBalance",
                table: "Users",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserPassword",
                table: "Users",
                type: "VARCHAR(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "BookmakerId",
                table: "Bookmakers",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "BanState",
                table: "Bookmakers",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BookmakerEmail",
                table: "Bookmakers",
                type: "VARCHAR(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "BookmakerMoneyBalance",
                table: "Bookmakers",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "BookmakerName",
                table: "Bookmakers",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BookmakerPassword",
                table: "Bookmakers",
                type: "VARCHAR(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_UserEmail",
                table: "Users",
                column: "UserEmail");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Bookmakers_BookmakerEmail",
                table: "Bookmakers",
                column: "BookmakerEmail");
        }
    }
}
