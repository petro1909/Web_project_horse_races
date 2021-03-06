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
    [Migration("20220511110044_AddRacesAndRaceParticipantsTablesAndModifiedHorseTable")]
    partial class AddRacesAndRaceParticipantsTablesAndModifiedHorseTable
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

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("Web_project_horse_races_db.Model.RaceParticipant", b =>
                {
                    b.Property<int>("RaceId")
                        .HasColumnType("INT")
                        .HasColumnName("RaceId");

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

                    b.HasKey("RaceId", "HorseId");

                    b.HasIndex("HorseId");

                    b.ToTable("RaceParticipants");
                });

            modelBuilder.Entity("Web_project_horse_races_db.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("UserId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                    b.Navigation("RaceParticipants");
                });

            modelBuilder.Entity("Web_project_horse_races_db.Model.User", b =>
                {
                    b.Navigation("UserBetProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
