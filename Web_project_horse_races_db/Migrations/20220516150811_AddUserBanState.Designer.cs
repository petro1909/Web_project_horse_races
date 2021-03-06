// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_project_horse_races_db.EntityFramework;

namespace Web_project_horse_races_db.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220516150811_AddUserBanState")]
    partial class AddUserBanState
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Web_project_horse_races_db.Model.Horse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("HorseId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Age")
                        .HasColumnType("TINYINT")
                        .HasColumnName("HorseAge");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("HorseName");

                    b.HasKey("Id");

                    b.ToTable("Horses");
                });

            modelBuilder.Entity("Web_project_horse_races_db.Model.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("RaceId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("RaceDate")
                        .HasColumnType("DateTime")
                        .HasColumnName("RaceDate");

                    b.Property<int>("RaceStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("Web_project_horse_races_db.Model.RaceBet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Coefficient")
                        .HasColumnType("float")
                        .HasColumnName("RaceBetCoefficient");

                    b.Property<int>("RaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("RaceId");

                    b.Property<int>("RaceParicipantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("RaceParticipantId");

                    b.Property<decimal>("TotalSum")
                        .HasColumnType("money")
                        .HasColumnName("RaceBetTotalSum");

                    b.Property<int>("UserBetCount")
                        .HasColumnType("INT")
                        .HasColumnName("RaceBetUserBetCount");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.HasIndex("RaceParicipantId")
                        .IsUnique();

                    b.ToTable("RaceBets");
                });

            modelBuilder.Entity("Web_project_horse_races_db.Model.RaceParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HorseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("HorseId");

                    b.Property<byte>("Number")
                        .HasColumnType("TINYINT")
                        .HasColumnName("RaceParticipantNumber");

                    b.Property<byte>("Position")
                        .HasColumnType("TINYINT")
                        .HasColumnName("RaceParticipantPosition");

                    b.Property<int>("RaceId")
                        .HasColumnType("INT")
                        .HasColumnName("RaceId");

                    b.HasKey("Id");

                    b.HasIndex("HorseId");

                    b.HasIndex("RaceId");

                    b.ToTable("RaceParticipants");
                });

            modelBuilder.Entity("Web_project_horse_races_db.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("UserId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BanState")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)")
                        .HasColumnName("UserEmail");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("UserName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)")
                        .HasColumnName("UserPassword");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Web_project_horse_races_db.Model.UserBet", b =>
                {
                    b.Property<int>("UserBetProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("UserBetProfileId");

                    b.Property<int>("RaceBetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("UserBetRaceBetId");

                    b.Property<decimal>("BetSum")
                        .HasColumnType("money")
                        .HasColumnName("UserBetSum");

                    b.Property<decimal>("PossibleWinSum")
                        .HasColumnType("money")
                        .HasColumnName("UserBetPossibleWin");

                    b.Property<double>("coefficient")
                        .HasColumnType("float")
                        .HasColumnName("UserBetCoefficient");

                    b.HasKey("UserBetProfileId", "RaceBetId");

                    b.HasIndex("RaceBetId");

                    b.ToTable("UserBets");
                });

            modelBuilder.Entity("Web_project_horse_races_db.Model.UserBetProfile", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("UserId");

                    b.Property<int>("BetCount")
                        .HasColumnType("INT")
                        .HasColumnName("UserBetCount");

                    b.Property<int>("LooseBets")
                        .HasColumnType("INT")
                        .HasColumnName("UserLooseBetCount");

                    b.Property<decimal>("MoneyBalance")
                        .HasColumnType("money")
                        .HasColumnName("UserMoneyBalance");

                    b.Property<int>("WinBets")
                        .HasColumnType("INT")
                        .HasColumnName("UserWinBetCount");

                    b.HasKey("UserId");

                    b.ToTable("UsersBetProfiles");
                });

            modelBuilder.Entity("Web_project_horse_races_db.Model.RaceBet", b =>
                {
                    b.HasOne("Web_project_horse_races_db.Model.Race", "Race")
                        .WithMany("RaceBets")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_project_horse_races_db.Model.RaceParticipant", "RaceParticipant")
                        .WithOne("RaceBet")
                        .HasForeignKey("Web_project_horse_races_db.Model.RaceBet", "RaceParicipantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Race");

                    b.Navigation("RaceParticipant");
                });

            modelBuilder.Entity("Web_project_horse_races_db.Model.RaceParticipant", b =>
                {
                    b.HasOne("Web_project_horse_races_db.Model.Horse", "Horse")
                        .WithMany("RaceParticipants")
                        .HasForeignKey("HorseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Web_project_horse_races_db.Model.Race", "Race")
                        .WithMany("RaceParticipants")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Horse");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("Web_project_horse_races_db.Model.UserBet", b =>
                {
                    b.HasOne("Web_project_horse_races_db.Model.RaceBet", "RaceBet")
                        .WithMany("UserBets")
                        .HasForeignKey("RaceBetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_project_horse_races_db.Model.UserBetProfile", "UserBetProfile")
                        .WithMany("UserBets")
                        .HasForeignKey("UserBetProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RaceBet");

                    b.Navigation("UserBetProfile");
                });

            modelBuilder.Entity("Web_project_horse_races_db.Model.UserBetProfile", b =>
                {
                    b.HasOne("Web_project_horse_races_db.Model.User", "User")
                        .WithOne("UserBetProfile")
                        .HasForeignKey("Web_project_horse_races_db.Model.UserBetProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Web_project_horse_races_db.Model.Horse", b =>
                {
                    b.Navigation("RaceParticipants");
                });

            modelBuilder.Entity("Web_project_horse_races_db.Model.Race", b =>
                {
                    b.Navigation("RaceBets");

                    b.Navigation("RaceParticipants");
                });

            modelBuilder.Entity("Web_project_horse_races_db.Model.RaceBet", b =>
                {
                    b.Navigation("UserBets");
                });

            modelBuilder.Entity("Web_project_horse_races_db.Model.RaceParticipant", b =>
                {
                    b.Navigation("RaceBet");
                });

            modelBuilder.Entity("Web_project_horse_races_db.Model.User", b =>
                {
                    b.Navigation("UserBetProfile");
                });

            modelBuilder.Entity("Web_project_horse_races_db.Model.UserBetProfile", b =>
                {
                    b.Navigation("UserBets");
                });
#pragma warning restore 612, 618
        }
    }
}
