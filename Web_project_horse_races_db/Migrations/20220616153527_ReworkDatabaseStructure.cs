using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class ReworkDatabaseStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_BookmakerBets_Bookmakers_UserId",
            //    table: "BookmakerBets");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_BookmakerBets_RaceParticipantsBets_RaceParticipantBetId",
            //    table: "BookmakerBets");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_UserBets_BookmakerBets_BookmakerBetId",
            //    table: "UserBets");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Users_BaseUsers_UserId",
            //    table: "Users");

            //migrationBuilder.DropTable(
            //    name: "BaseUsers");

            //migrationBuilder.DropTable(
            //    name: "RaceParticipantsBets");

            //migrationBuilder.DropTable(
            //    name: "RaceBetType");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Bookmakers",
            //    table: "Bookmakers");

            //migrationBuilder.DropIndex(
            //    name: "IX_BookmakerBets_RaceParticipantBetId",
            //    table: "BookmakerBets");

            //migrationBuilder.DropColumn(
            //    name: "UserBetCount",
            //    table: "Users");

            //migrationBuilder.DropColumn(
            //    name: "UserLooseBetCount",
            //    table: "Users");

            //migrationBuilder.DropColumn(
            //    name: "UserWinBetCount",
            //    table: "Users");

            //migrationBuilder.DropColumn(
            //    name: "UserId",
            //    table: "Bookmakers");

            //migrationBuilder.DropColumn(
            //    name: "RaceParticipantBetId",
            //    table: "BookmakerBets");

            //migrationBuilder.RenameColumn(
            //    name: "UserMoneyBalance",
            //    table: "Users",
            //    newName: "MoneyBalance");

            //migrationBuilder.RenameColumn(
            //    name: "UserId",
            //    table: "Users",
            //    newName: "Id");

            //migrationBuilder.RenameColumn(
            //    name: "RoleName",
            //    table: "UserRoles",
            //    newName: "Name");

            //migrationBuilder.RenameColumn(
            //    name: "UserBetSum",
            //    table: "UserBets",
            //    newName: "BetSum");

            //migrationBuilder.RenameColumn(
            //    name: "UserBetPossibleWin",
            //    table: "UserBets",
            //    newName: "PossibleWin");

            //migrationBuilder.RenameColumn(
            //    name: "BookmakerBetId",
            //    table: "UserBets",
            //    newName: "UserBetTypeId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_UserBets_BookmakerBetId",
            //    table: "UserBets",
            //    newName: "IX_UserBets_UserBetTypeId");

            //migrationBuilder.RenameColumn(
            //    name: "BookmakerMoneyBalance",
            //    table: "Bookmakers",
            //    newName: "MoneyBalance");

            //migrationBuilder.RenameColumn(
            //    name: "UserId",
            //    table: "BookmakerBets",
            //    newName: "RaceParticipantId");




            //--
            //migrationBuilder.RenameIndex(
            //    name: "IX_BookmakerBets_UserId",
            //    table: "BookmakerBets",
            //    newName: "IX_BookmakerBets_RaceParticipantId");


            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "Users",
            //    type: "INT",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "INT")
            //    .Annotation("SqlServer:Identity", "1, 1");




            //migrationBuilder.AddColumn<bool>(
            //    name: "BanState",
            //    table: "Users",
            //    type: "BIT",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<string>(
            //    name: "Email",
            //    table: "Users",
            //    type: "VARCHAR(50)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "Name",
            //    table: "Users",
            //    type: "VARCHAR(50)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "Password",
            //    table: "Users",
            //    type: "VARCHAR(30)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<int>(
            //    name: "RoleId",
            //    table: "Users",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<double>(
            //    name: "Coefficient",
            //    table: "UserBets",
            //    type: "float",
            //    nullable: false,
            //    defaultValue: 0.0);


            //migrationBuilder.DropTable(
            //    name: "Bookmakers");

            //migrationBuilder.CreateTable(
            //    name: "Bookmakers",
            //    columns: table => new
            //    {
            //        Name = table.Column<string>(type: "VARCHAR(20)", nullable: false),
            //        Password = table.Column<string>(type: "VARCHAR(50)", nullable: false),
            //        MoneyBalance = table.Column<decimal>(type: "money", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Bookmakers", b => b.Name);
            //    });

            //migrationBuilder.AddColumn<string>(
            //    name: "BookmakerName",
            //    table: "BookmakerBets",
            //    type: "varchar(20)",
            //    nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "BookmakerBetUserBet",
            //    columns: table => new
            //    {
            //        BookmakerBetsId = table.Column<int>(type: "INT", nullable: false),
            //        UserBetsId = table.Column<int>(type: "INT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BookmakerBetUserBet", x => new { x.BookmakerBetsId, x.UserBetsId });
            //        table.ForeignKey(
            //            name: "FK_BookmakerBetUserBet_BookmakerBets_BookmakerBetsId",
            //            column: x => x.BookmakerBetsId,
            //            principalTable: "BookmakerBets",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_BookmakerBetUserBet_UserBets_UserBetsId",
            //            column: x => x.UserBetsId,
            //            principalTable: "UserBets",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserBetType",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "INT", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "varchar(25)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserBetType", x => x.Id);
            //        table.UniqueConstraint("AK_UserBetType_Name", x => x.Name);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Users_Email",
            //    table: "Users",
            //    column: "Email",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Users_RoleId",
            //    table: "Users",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BookmakerBets_BookmakerName",
            //    table: "BookmakerBets",
            //    column: "BookmakerName");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BookmakerBetUserBet_UserBetsId",
            //    table: "BookmakerBetUserBet",
            //    column: "UserBetsId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_BookmakerBets_Bookmakers_BookmakerName",
            //    table: "BookmakerBets",
            //    column: "BookmakerName",
            //    principalTable: "Bookmakers",
            //    principalColumn: "Name",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_BookmakerBets_RaceParticipants_RaceParticipantId",
            //    table: "BookmakerBets",
            //    column: "RaceParticipantId",
            //    principalTable: "RaceParticipants",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_UserBets_UserBetType_UserBetTypeId",
            //    table: "UserBets",
            //    column: "UserBetTypeId",
            //    principalTable: "UserBetType",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Users_UserRoles_RoleId",
            //    table: "Users",
            //    column: "RoleId",
            //    principalTable: "UserRoles",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookmakerBets_Bookmakers_BookmakerName",
                table: "BookmakerBets");

            migrationBuilder.DropForeignKey(
                name: "FK_BookmakerBets_RaceParticipants_RaceParticipantId",
                table: "BookmakerBets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBets_UserBetType_UserBetTypeId",
                table: "UserBets");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "BookmakerBetUserBet");

            migrationBuilder.DropTable(
                name: "UserBetType");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmakers",
                table: "Bookmakers");

            migrationBuilder.DropIndex(
                name: "IX_BookmakerBets_BookmakerName",
                table: "BookmakerBets");

            migrationBuilder.DropColumn(
                name: "BanState",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Coefficient",
                table: "UserBets");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Bookmakers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Bookmakers");

            migrationBuilder.DropColumn(
                name: "BookmakerName",
                table: "BookmakerBets");

            migrationBuilder.RenameColumn(
                name: "MoneyBalance",
                table: "Users",
                newName: "UserMoneyBalance");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserRoles",
                newName: "RoleName");

            migrationBuilder.RenameColumn(
                name: "PossibleWin",
                table: "UserBets",
                newName: "UserBetPossibleWin");

            migrationBuilder.RenameColumn(
                name: "BetSum",
                table: "UserBets",
                newName: "UserBetSum");

            migrationBuilder.RenameColumn(
                name: "UserBetTypeId",
                table: "UserBets",
                newName: "BookmakerBetId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBets_UserBetTypeId",
                table: "UserBets",
                newName: "IX_UserBets_BookmakerBetId");

            migrationBuilder.RenameColumn(
                name: "MoneyBalance",
                table: "Bookmakers",
                newName: "BookmakerMoneyBalance");

            migrationBuilder.RenameColumn(
                name: "RaceParticipantId",
                table: "BookmakerBets",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BookmakerBets_RaceParticipantId",
                table: "BookmakerBets",
                newName: "IX_BookmakerBets_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Users",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserBetCount",
                table: "Users",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserLooseBetCount",
                table: "Users",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserWinBetCount",
                table: "Users",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Bookmakers",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RaceParticipantBetId",
                table: "BookmakerBets",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmakers",
                table: "Bookmakers",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "BaseUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BanState = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    UserEmail = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    UserName = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    UserPassword = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseUsers", x => x.UserId);
                    table.UniqueConstraint("AK_BaseUsers_UserEmail", x => x.UserEmail);
                    table.ForeignKey(
                        name: "FK_BaseUsers_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceBetType",
                columns: table => new
                {
                    RaceBetTypeId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceBetTypeName = table.Column<string>(type: "varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceBetType", x => x.RaceBetTypeId);
                    table.UniqueConstraint("AK_RaceBetType_RaceBetTypeName", x => x.RaceBetTypeName);
                });

            migrationBuilder.CreateTable(
                name: "RaceParticipantsBets",
                columns: table => new
                {
                    RaceParticipantBetId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceBetType = table.Column<int>(type: "INT", nullable: false),
                    RaceParticipantId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceParticipantsBets", x => x.RaceParticipantBetId);
                    table.ForeignKey(
                        name: "FK_RaceParticipantsBets_RaceBetType_RaceBetType",
                        column: x => x.RaceBetType,
                        principalTable: "RaceBetType",
                        principalColumn: "RaceBetTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceParticipantsBets_RaceParticipants_RaceParticipantId",
                        column: x => x.RaceParticipantId,
                        principalTable: "RaceParticipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookmakerBets_RaceParticipantBetId",
                table: "BookmakerBets",
                column: "RaceParticipantBetId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseUsers_RoleId",
                table: "BaseUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceParticipantsBets_RaceBetType",
                table: "RaceParticipantsBets",
                column: "RaceBetType");

            migrationBuilder.CreateIndex(
                name: "IX_RaceParticipantsBets_RaceParticipantId",
                table: "RaceParticipantsBets",
                column: "RaceParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookmakerBets_Bookmakers_UserId",
                table: "BookmakerBets",
                column: "UserId",
                principalTable: "Bookmakers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookmakerBets_RaceParticipantsBets_RaceParticipantBetId",
                table: "BookmakerBets",
                column: "RaceParticipantBetId",
                principalTable: "RaceParticipantsBets",
                principalColumn: "RaceParticipantBetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmakers_BaseUsers_UserId",
                table: "Bookmakers",
                column: "UserId",
                principalTable: "BaseUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBets_BookmakerBets_BookmakerBetId",
                table: "UserBets",
                column: "BookmakerBetId",
                principalTable: "BookmakerBets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_BaseUsers_UserId",
                table: "Users",
                column: "UserId",
                principalTable: "BaseUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
