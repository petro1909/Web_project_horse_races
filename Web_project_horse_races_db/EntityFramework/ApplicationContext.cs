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
        public DbSet<Horse> Horses => Set<Horse>();
        public DbSet<Race> Races => Set<Race>();
        public DbSet<RaceParticipant> RaceParticipants => Set<RaceParticipant>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<UserBet> UserBets => Set<UserBet>();
        public DbSet<BetType> BetTypes => Set<BetType>();
        public DbSet<Bookmaker> Bookmakers => Set<Bookmaker>();
        public DbSet<BookmakerBet> BookmakerBets => Set<BookmakerBet>();
        public DbSet<BookmakerRaceBet> BookmakerRaceBets => Set<BookmakerRaceBet>();
        public DbSet<RaceParticipantBet> RaceParticipantBet => Set<RaceParticipantBet>();


        public ApplicationContext()
        {
            connectionString = DbConfigurationManager.GetConnectionStringFromJSONFile();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Horse>(HorseConfig);
            modelBuilder.Entity<Race>(RaceConfig);
            modelBuilder.Entity<RaceParticipant>(RaceParticipantConfig);

            modelBuilder.Entity<RaceParticipantBet>(RaceParticipantBetTypeConfig);
            modelBuilder.Entity<BetType>(BetTypeConfig);

            modelBuilder.Entity<Bookmaker>(BookmakerConfig);
            modelBuilder.Entity<BookmakerBet>(BookmakerBetConfig);
            modelBuilder.Entity<BookmakerRaceBet>(BookmakerRaceBetConfig);
            
            modelBuilder.Entity<User>(UserConfig);
            modelBuilder.Entity<UserRole>(UserRoleConfig);
            modelBuilder.Entity<UserBet>(UserBetConfig);
        }

        private void UserConfig(EntityTypeBuilder<User> user)
        {
            user.ToTable("Users");

            user.Property(u => u.Id).HasColumnName("Id").HasColumnType("INT").ValueGeneratedOnAdd();
            user.HasKey(u => u.Id);

            user.Property(u => u.Name).HasColumnName("Name").HasColumnType("VARCHAR(50)").IsRequired();
            user.Property(u => u.Email).HasColumnName("Email").HasColumnType("VARCHAR(50)").IsRequired();
            user.HasIndex(u => u.Email).IsUnique();
            user.Property(u => u.Password).HasColumnName("Password").HasColumnType("VARCHAR(30)").IsRequired();
            user.Property(u => u.BanState).HasColumnType("BanState").HasColumnType("BIT").HasDefaultValue(0);

            user.Property(u => u.MoneyBalance).HasColumnName("MoneyBalance").HasColumnType("money").IsRequired();
            user.HasMany(b => b.UserBets).WithOne(ub => ub.User).HasForeignKey(ub => ub.UserId).OnDelete(DeleteBehavior.Cascade);
        }

        private void BookmakerConfig(EntityTypeBuilder<Bookmaker> bookmaker)
        {
            bookmaker.ToTable("Bookmakers");
            
            bookmaker.Property(b => b.Name).HasColumnName("Name").HasColumnType("VARCHAR(20)").IsRequired();
            bookmaker.HasKey(b => b.Name);
            bookmaker.Property(u => u.Password).HasColumnName("Password").HasColumnType("VARCHAR(30)").IsRequired();
            
            bookmaker.Property(u => u.MoneyBalance).HasColumnName("MoneyBalance").HasColumnType("money").IsRequired();
            bookmaker.HasMany(b => b.BookmakerRaceBets).WithOne(ub => ub.Bookmaker).HasForeignKey(ub => ub.BookmakerName).OnDelete(DeleteBehavior.Cascade);
        }

        private void UserRoleConfig(EntityTypeBuilder<UserRole> userRole)
        {
            userRole.ToTable("UserRoles");
            userRole.Property(ur => ur.RoleName).HasColumnName("Name").HasColumnType("varchar(30)");
            userRole.HasMany(ur => ur.Users).WithOne(u => u.Role).HasForeignKey(u => u.RoleId);
        }

        private void UserBetConfig(EntityTypeBuilder<UserBet> userBet)
        {
            userBet.ToTable("UserBets");

            userBet.Property(ub => ub.Id).HasColumnName("Id").HasColumnType("INT").ValueGeneratedOnAdd();
            userBet.HasKey(ub => ub.Id);

            userBet.Property(ub => ub.UserId).HasColumnName("UserId").HasColumnType("INT").ValueGeneratedOnAdd();
           
            userBet.Property(ub => ub.BetSum).HasColumnName("BetSum").HasColumnType("money");
            userBet.Property(ub => ub.Coefficient).HasColumnName("Coefficient").HasColumnType("float");
            userBet.Property(ub => ub.PossibleWinSum).HasColumnName("PossibleWin").HasColumnType("money");
            userBet.Property(ub => ub.BetStatus).HasColumnName("BetStatus").HasColumnType("varchar(20)");

            userBet.HasMany(ub => ub.BookmakerBets).WithMany(bb => bb.UserBets);
        }

        private void BookmakerBetConfig(EntityTypeBuilder<BookmakerBet> bookmakerBet)
        {
            bookmakerBet.ToTable("BookmakerBets");
            bookmakerBet.Property(bb => bb.Id).HasColumnName("Id").HasColumnType("INT").ValueGeneratedOnAdd();
            bookmakerBet.HasKey(bb => bb.Id);
            
            bookmakerBet.Property(bb => bb.RaceParticipantBetId).HasColumnName("RaceParticipantBetId").HasColumnType("INT").ValueGeneratedOnAdd();

            bookmakerBet.Property(bb => bb.Coefficient).HasColumnName("Coefficient").HasColumnType("float");
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
            race.Property(r => r.RaceStatus).HasColumnName("RaceStatus").HasColumnType("varchar(30)");
            
            race.HasMany(r => r.RaceParticipants).WithOne(rp => rp.Race).HasForeignKey(rp => rp.RaceId).OnDelete(DeleteBehavior.Cascade);
            race.HasMany(r => r.BookmakerRaceBets).WithOne(brb => brb.Race).HasForeignKey(brb => brb.RaceId).OnDelete(DeleteBehavior.Cascade);

        }
        private void RaceParticipantConfig(EntityTypeBuilder<RaceParticipant> raceParticipant)
        {
            raceParticipant.ToTable("RaceParticipants");
            raceParticipant.Property(rp => rp.HorseId).HasColumnName("HorseId").HasColumnType("INT").ValueGeneratedOnAdd();
            raceParticipant.Property(rp => rp.RaceId).HasColumnName("RaceId").HasColumnType("INT");
            raceParticipant.HasKey(rp => rp.Id);
            raceParticipant.Property(rp => rp.Number).HasColumnName("RaceParticipantNumber").HasColumnType("TINYINT").IsRequired();
            raceParticipant.Property(rp => rp.Position).HasColumnName("RaceParticipantPosition").HasColumnType("TINYINT");
            raceParticipant.HasMany(rp => rp.BetTypes).WithOne(rb => rb.RaceParticipant).HasForeignKey(rb => rb.RaceParticipantId).OnDelete(DeleteBehavior.Cascade);
        }

        private void RaceParticipantBetTypeConfig(EntityTypeBuilder<RaceParticipantBet> raceParticipantBet)
        {
            raceParticipantBet.ToTable("RaceParticipantsBets");
            raceParticipantBet.Property(rb => rb.Id).HasColumnName("RaceParticipantBetId").HasColumnType("INT").ValueGeneratedOnAdd();
            raceParticipantBet.Property(rb => rb.RaceParticipantId).HasColumnName("RaceParticipantId").HasColumnType("INT").ValueGeneratedOnAdd();
            raceParticipantBet.HasKey(rb => rb.Id);
            raceParticipantBet.Property(rb => rb.BetTypeId).HasColumnName("RaceBetType").HasColumnType("INT");
            raceParticipantBet.HasMany(rb => rb.BookmakerBets).WithOne(ub => ub.RaceParticipantBet).HasForeignKey(ub => ub.RaceParticipantBetId).OnDelete(DeleteBehavior.Cascade);
        }

        private void BetTypeConfig(EntityTypeBuilder<BetType> raceBetType)
        {
            raceBetType.ToTable("BetType");
            raceBetType.Property(rbt => rbt.Id).HasColumnName("Id").HasColumnType("INT").ValueGeneratedOnAdd();
            raceBetType.Property(rbt => rbt.Name).HasColumnName("Name").HasColumnType("varchar(25)");
            raceBetType.HasAlternateKey(rbt => rbt.Name);
            raceBetType.HasMany(rbt => rbt.RaceParticipantsBets).WithOne(rpb => rpb.BetType).HasForeignKey(rpb => rpb.BetTypeId);
        }

        private void BookmakerRaceBetConfig(EntityTypeBuilder<BookmakerRaceBet> bookmakerRaceBet)
        {
            bookmakerRaceBet.ToTable("BookmakerRaceBet");

            bookmakerRaceBet.Property(brb => brb.Id).HasColumnName("Id").HasColumnType("INT").ValueGeneratedOnAdd();
            bookmakerRaceBet.HasKey(brb => brb.Id);

            bookmakerRaceBet.HasMany(brb => brb.BookmakerBets).WithOne(bb => bb.BookmakerRaceBet).HasForeignKey(bb => bb.BookmakerRaceBetId).OnDelete(DeleteBehavior.Cascade);
            bookmakerRaceBet.HasMany(brb => brb.UserBets).WithOne(ub => ub.BookmakerRaceBet).HasForeignKey(ub => ub.BookmakerRaceBetId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
