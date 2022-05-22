using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web_project_horse_races_db.Model;
using Microsoft.Extensions.Configuration;
using System.IO;
using Web_project_horse_races_db.DbUtil;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Web_project_horse_races_db.EntityFramework
{
    public class ApplicationContext : DbContext
    {
        private readonly string connectionString;
        public DbSet<User> Users => Set<User>();
        public DbSet<UserBetProfile> UserBetProfiles => Set<UserBetProfile>();
        public DbSet<Horse> Horses => Set<Horse>();
        public DbSet<Race> Races => Set<Race>();
        public DbSet<RaceParticipant> RaceParticipants => Set<RaceParticipant>();
        public DbSet<RaceBet> RaceBets => Set<RaceBet>();
        public DbSet<UserBet> UserBets => Set<UserBet>();
        
        public ApplicationContext()
        {
            //Database.EnsureCreated();
            connectionString = DbConfigurationManager.GetConnectionStringFromJSONFile();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(UserConfig);
            modelBuilder.Entity<UserBetProfile>(UserBetProfileConfig);
            modelBuilder.Entity<Horse>(HorseConfig);
            modelBuilder.Entity<Race>(RaceConfig);
            modelBuilder.Entity<RaceParticipant>(RaceParticipantConfig);
            modelBuilder.Entity<RaceBet>(RaceBetConfig);
            modelBuilder.Entity<UserBet>(UserBetConfig);

        }

        private void UserConfig(EntityTypeBuilder<User> user)
        {
            user.ToTable("Users");
            user.Property(u => u.Id).HasColumnName("UserId").HasColumnType("INT").ValueGeneratedOnAdd();
            user.HasKey(u => u.Id);
            user.Property(u => u.Name).HasColumnName("UserName").HasColumnType("VARCHAR(50)").IsRequired();
            user.Property(u => u.Email).HasColumnName("UserEmail").HasColumnType("VARCHAR(30)").IsRequired();
            user.HasAlternateKey(u => u.Email);
            user.Property(u => u.Password).HasColumnName("UserPassword").HasColumnType("VARCHAR(30)").IsRequired();
            user.Property(u => u.BanState).HasColumnType("UserBanState").HasColumnType("BIT").HasDefaultValue(0);
            user.HasOne(u => u.UserBetProfile).WithOne(b => b.User).HasForeignKey<UserBetProfile>(b => b.UserId).OnDelete(DeleteBehavior.Cascade);
        }

        private void UserBetProfileConfig(EntityTypeBuilder<UserBetProfile> userBetProfile)
        {
            userBetProfile.ToTable("UsersBetProfiles");
            userBetProfile.Property(b => b.UserId).HasColumnName("UserId").HasColumnType("INT").ValueGeneratedOnAdd();
            userBetProfile.HasKey(b => b.UserId);
            userBetProfile.Property(b => b.MoneyBalance).HasColumnName("UserMoneyBalance").HasColumnType("money").IsRequired();
            userBetProfile.Property(b => b.BetCount).HasColumnName("UserBetCount").HasColumnType("INT").IsRequired();
            userBetProfile.Property(b => b.WinBets).HasColumnName("UserWinBetCount").HasColumnType("INT").IsRequired();
            userBetProfile.Property(b => b.LooseBets).HasColumnName("UserLooseBetCount").HasColumnType("INT").IsRequired();
            userBetProfile.HasMany(b => b.UserBets).WithOne(ub => ub.UserBetProfile).HasForeignKey(ub => ub.UserBetProfileId).OnDelete(DeleteBehavior.Cascade);
        }

        private void HorseConfig(EntityTypeBuilder<Horse> horse)
        {
            horse.ToTable("Horses");
            horse.Property(h => h.Id).HasColumnName("HorseId").HasColumnType("INT").ValueGeneratedOnAdd();
            horse.HasKey(h => h.Id);
            horse.Property(h => h.Name).HasColumnName("HorseName").HasColumnType("VARCHAR(255)").IsRequired();
            horse.Property(h => h.Age).HasColumnName("HorseAge").HasColumnType("TINYINT");
            horse.HasMany(h => h.RaceParticipants).WithOne(rp => rp.Horse).HasForeignKey(rp => rp.HorseId).OnDelete(DeleteBehavior.NoAction);
        }
        private void RaceConfig(EntityTypeBuilder<Race> race)
        {
            race.ToTable("Races");
            race.Property(r => r.Id).HasColumnName("RaceId").HasColumnType("INT").ValueGeneratedOnAdd();
            race.HasKey(r => r.Id);
            race.Property(r => r.RaceDate).HasColumnName("RaceDate").HasColumnType("DateTime").IsRequired();
            race.HasMany(r => r.RaceParticipants).WithOne(rp => rp.Race).HasForeignKey(rp => rp.RaceId).OnDelete(DeleteBehavior.NoAction);
            race.HasMany(r => r.RaceBets).WithOne(rb => rb.Race).HasForeignKey(rb => rb.RaceId).OnDelete(DeleteBehavior.Cascade);
            race.Ignore(r => r.RaceWinner);
        }
        private void RaceParticipantConfig(EntityTypeBuilder<RaceParticipant> raceParticipant)
        {
            raceParticipant.ToTable("RaceParticipants");
            raceParticipant.Property(rp => rp.HorseId).HasColumnName("HorseId").HasColumnType("INT").ValueGeneratedOnAdd();
            raceParticipant.Property(rp => rp.RaceId).HasColumnName("RaceId").HasColumnType("INT");
            raceParticipant.HasKey(rp => rp.Id);
            raceParticipant.Property(rp => rp.Number).HasColumnName("RaceParticipantNumber").HasColumnType("TINYINT").IsRequired();
            raceParticipant.Property(rp => rp.Position).HasColumnName("RaceParticipantPosition").HasColumnType("TINYINT");
            raceParticipant.HasOne(rp => rp.RaceBet).WithOne(rb => rb.RaceParticipant).HasForeignKey<RaceBet>(rb => rb.RaceParicipantId).OnDelete(DeleteBehavior.Cascade);
        }

        private void RaceBetConfig(EntityTypeBuilder<RaceBet> raceBet)
        {
            raceBet.Property(rb => rb.RaceId).HasColumnName("RaceId").HasColumnType("INT").ValueGeneratedOnAdd();
            raceBet.Property(rb => rb.RaceParicipantId).HasColumnName("RaceParticipantId").HasColumnType("INT").ValueGeneratedOnAdd();
            raceBet.HasKey(rb => rb.Id);
            raceBet.Property(rb => rb.Coefficient).HasColumnName("RaceBetCoefficient").HasColumnType("float");
            raceBet.Property(rb => rb.TotalSum).HasColumnName("RaceBetTotalSum").HasColumnType("money");
            raceBet.Property(rb => rb.UserBetCount).HasColumnName("RaceBetUserBetCount").HasColumnType("INT");
            raceBet.HasMany(rb => rb.UserBets).WithOne(ub => ub.RaceBet).HasForeignKey(ub => ub.RaceBetId).OnDelete(DeleteBehavior.Cascade);
        }

        private void UserBetConfig(EntityTypeBuilder<UserBet> userBet)
        {
            userBet.Property(ub => ub.UserBetProfileId).HasColumnName("UserBetProfileId").HasColumnType("INT").ValueGeneratedOnAdd();
            userBet.Property(ub => ub.RaceBetId).HasColumnName("UserBetRaceBetId").HasColumnType("INT").ValueGeneratedOnAdd();
            userBet.HasKey(ub => new { ub.UserBetProfileId, ub.RaceBetId });
            userBet.Property(ub => ub.BetSum).HasColumnName("UserBetSum").HasColumnType("money");
            userBet.Property(ub => ub.coefficient).HasColumnName("UserBetCoefficient").HasColumnType("float");
            userBet.Property(ub => ub.PossibleWinSum).HasColumnName("UserBetPossibleWin").HasColumnType("money");
        }
    }
}
