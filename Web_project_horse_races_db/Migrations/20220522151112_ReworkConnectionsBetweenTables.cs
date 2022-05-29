using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_project_horse_races_db.Migrations
{
    public partial class ReworkConnectionsBetweenTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceParticipantsBets_RaceBetType_RaceBetTypeId",
                table: "RaceParticipantsBets");

            migrationBuilder.DropTable(
                name: "UsersBetProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBets",
                table: "UserBets");

            migrationBuilder.DropColumn(
                name: "UserBetCoefficient",
                table: "UserBets");

            migrationBuilder.DropColumn(
                name: "RaceBetCoefficient",
                table: "RaceParticipantsBets");

            migrationBuilder.DropColumn(
                name: "RaceBetTotalSum",
                table: "RaceParticipantsBets");

            migrationBuilder.DropColumn(
                name: "RaceBetUserBetCount",
                table: "RaceParticipantsBets");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserBets",
                type : "INT");

            migrationBuilder.RenameColumn(
                name: "UserBetProfileId",
                table: "UserBets",
                newName: "BookmakerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBets_UserId",
                table: "UserBets",
                column : "UserId");

            migrationBuilder.RenameColumn(
                name: "RaceBetTypeId",
                table: "RaceParticipantsBets",
                newName: "RaceBetType");

            //migrationBuilder.RenameIndex(
            //    name: "IX_RaceParticipantsBets_RaceBetTypeId",
            //    table: "RaceParticipantsBets",
            //    newName: "IX_RaceParticipantsBets_RaceBetType");


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

            migrationBuilder.AddColumn<decimal>(
                name: "UserMoneyBalance",
                table: "Users",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "UserWinBetCount",
                table: "Users",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserBets",
                type: "INT",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "RaceBetTypeName",
                table: "RaceBetType",
                type: "varchar(25)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBets",
                table: "UserBets",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Bookmakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserMoneyBalance = table.Column<decimal>(type: "money", nullable: false),
                    UserName = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    UserEmail = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    UserPassword = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    BanState = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmakers", x => x.Id);
                    table.UniqueConstraint("AK_Bookmakers_UserEmail", x => x.UserEmail);
                });

            migrationBuilder.CreateTable(
                name: "BookmakerBets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookmakerId = table.Column<int>(type: "INT", nullable: false),
                    RaceParticipantBetId = table.Column<int>(type: "INT", nullable: false),
                    Coefficient = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookmakerBets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookmakerBets_Bookmakers_BookmakerId",
                        column: x => x.BookmakerId,
                        principalTable: "Bookmakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookmakerBets_RaceParticipantsBets_RaceParticipantBetId",
                        column: x => x.RaceParticipantBetId,
                        principalTable: "RaceParticipantsBets",
                        principalColumn: "RaceParticipantBetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBets_BookmakerId",
                table: "UserBets",
                column: "BookmakerId");

            migrationBuilder.CreateIndex(
                name: "IX_BookmakerBets_BookmakerId",
                table: "BookmakerBets",
                column: "BookmakerId");

            migrationBuilder.CreateIndex(
                name: "IX_BookmakerBets_RaceParticipantId",
                table: "BookmakerBets",
                column: "RaceParticipantBetId");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceParticipantsBets_RaceBetType_RaceBetType",
                table: "RaceParticipantsBets",
                column: "RaceBetType",
                principalTable: "RaceBetType",
                principalColumn: "RaceBetTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBets_BookmakerBets_BookmakerId",
                table: "UserBets",
                column: "BookmakerId",
                principalTable: "BookmakerBets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBets_Users_UserId",
                table: "UserBets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceParticipantsBets_RaceBetType_RaceBetType",
                table: "RaceParticipantsBets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBets_BookmakerBets_BookmakerId",
                table: "UserBets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBets_Users_UserId",
                table: "UserBets");

            migrationBuilder.DropTable(
                name: "BookmakerBets");

            migrationBuilder.DropTable(
                name: "Bookmakers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBets",
                table: "UserBets");

            migrationBuilder.DropIndex(
                name: "IX_UserBets_BookmakerId",
                table: "UserBets");

            migrationBuilder.DropColumn(
                name: "UserBetCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserLooseBetCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserMoneyBalance",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserWinBetCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserBets");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserBets",
                newName: "UserBetRaceParticipantBetId");

            migrationBuilder.RenameColumn(
                name: "BookmakerId",
                table: "UserBets",
                newName: "UserBetProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBets_UserId",
                table: "UserBets",
                newName: "IX_UserBets_UserBetRaceParticipantBetId");

            migrationBuilder.RenameColumn(
                name: "RaceBetType",
                table: "RaceParticipantsBets",
                newName: "RaceBetTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_RaceParticipantsBets_RaceBetType",
                table: "RaceParticipantsBets",
                newName: "IX_RaceParticipantsBets_RaceBetTypeId");

            migrationBuilder.RenameColumn(
                name: "RaceBetTypeName",
                table: "RaceBetType",
                newName: "varchar(25)");

            migrationBuilder.AddColumn<double>(
                name: "UserBetCoefficient",
                table: "UserBets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RaceBetCoefficient",
                table: "RaceParticipantsBets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "RaceBetTotalSum",
                table: "RaceParticipantsBets",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "RaceBetUserBetCount",
                table: "RaceParticipantsBets",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "varchar(25)",
                table: "RaceBetType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(25)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBets",
                table: "UserBets",
                columns: new[] { "UserBetProfileId", "UserBetRaceParticipantBetId" });

            migrationBuilder.CreateTable(
                name: "UsersBetProfiles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INT", nullable: false),
                    UserBetCount = table.Column<int>(type: "INT", nullable: false),
                    UserLooseBetCount = table.Column<int>(type: "INT", nullable: false),
                    UserMoneyBalance = table.Column<decimal>(type: "money", nullable: false),
                    UserWinBetCount = table.Column<int>(type: "INT", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_RaceParticipantsBets_RaceBetType_RaceBetTypeId",
                table: "RaceParticipantsBets",
                column: "RaceBetTypeId",
                principalTable: "RaceBetType",
                principalColumn: "RaceBetTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBets_RaceParticipantsBets_UserBetRaceParticipantBetId",
                table: "UserBets",
                column: "UserBetRaceParticipantBetId",
                principalTable: "RaceParticipantsBets",
                principalColumn: "RaceParticipanrBetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBets_UsersBetProfiles_UserBetProfileId",
                table: "UserBets",
                column: "UserBetProfileId",
                principalTable: "UsersBetProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
