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
        public DbSet<BaseUser> BaseUsers => Set<BaseUser>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Bookmaker> Bookmakers => Set<Bookmaker>();
        public DbSet<UserRole> Roles => Set<UserRole>();
        public DbSet<UserBet> UserBets => Set<UserBet>();
        public DbSet<BookmakerBet> BookmakerBets => Set<BookmakerBet>();
        public DbSet<Horse> Horses => Set<Horse>();
        public DbSet<Race> Races => Set<Race>();
        public DbSet<RaceParticipant> RaceParticipants => Set<RaceParticipant>();
        public DbSet<RaceParticipantBet> RaceBets => Set<RaceParticipantBet>();
        public DbSet<RaceBetType> RaceBetTypes => Set<RaceBetType>();
        
        public ApplicationContext()
        {
            //Database.EnsureCreated();
            connectionString = DbConfigurationManager.GetConnectionStringFromJSONFile();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseUser>(BaseUserConfig);
            modelBuilder.Entity<User>(UserConfig);
            modelBuilder.Entity<Bookmaker>(BookmakerConfig);
            modelBuilder.Entity<UserRole>(UserRoleConfig);
            modelBuilder.Entity<UserBet>(UserBetConfig);
            modelBuilder.Entity<BookmakerBet>(BookmakerBetConfig);
            modelBuilder.Entity<Horse>(HorseConfig);
            modelBuilder.Entity<Race>(RaceConfig);
            modelBuilder.Entity<RaceParticipant>(RaceParticipantConfig);
            modelBuilder.Entity<RaceParticipantBet>(RaceParticipantBetConfig);
            
            modelBuilder.Entity<RaceBetType>(RaceBetTypeConfig);

        }

        private void BaseUserConfig(EntityTypeBuilder<BaseUser> baseUser)
        {
            baseUser.Property(u => u.Id).HasColumnName("UserId").HasColumnType("INT").ValueGeneratedOnAdd();
            baseUser.HasKey(u => u.Id);

            baseUser.Property(u => u.Name).HasColumnName("UserName").HasColumnType("VARCHAR(50)").IsRequired();
            baseUser.Property(u => u.Email).HasColumnName("UserEmail").HasColumnType("VARCHAR(30)").IsRequired();
            baseUser.HasAlternateKey(u => u.Email);

            baseUser.Property(u => u.Password).HasColumnName("UserPassword").HasColumnType("VARCHAR(30)").IsRequired();
            baseUser.Property(u => u.BanState).HasColumnType("UserBanState").HasColumnType("BIT").HasDefaultValue(0);
        }

        private void UserConfig(EntityTypeBuilder<User> user)
        {
            user.ToTable("Users");
            
            user.Property(u => u.BetCount).HasColumnName("UserBetCount").HasColumnType("INT").IsRequired();
            user.Property(u => u.WinBets).HasColumnName("UserWinBetCount").HasColumnType("INT").IsRequired();
            user.Property(u => u.LooseBets).HasColumnName("UserLooseBetCount").HasColumnType("INT").IsRequired();
            user.Property(u => u.MoneyBalance).HasColumnName("UserMoneyBalance").HasColumnType("money").IsRequired();
            user.HasMany(b => b.UserBets).WithOne(ub => ub.User).HasForeignKey(ub => ub.UserId).OnDelete(DeleteBehavior.Cascade);
        }

        private void BookmakerConfig(EntityTypeBuilder<Bookmaker> bookmaker)
        {
            bookmaker.ToTable("Bookmakers");
            bookmaker.Property(u => u.MoneyBalance).HasColumnName("BookmakerMoneyBalance").HasColumnType("money").IsRequired();
            bookmaker.HasMany(b => b.BookmakerBets).WithOne(ub => ub.Bookmaker).HasForeignKey(ub => ub.BookmakerId).OnDelete(DeleteBehavior.Cascade);
        }

        private void UserRoleConfig(EntityTypeBuilder<UserRole> userRole)
        {
            userRole.ToTable("UserRoles");
            userRole.Property(ur => ur.RoleName).HasColumnName("RoleName").HasColumnType("varchar(30)");
            userRole.HasMany(ur => ur.Users).WithOne(u => u.Role).HasForeignKey(u => u.RoleId);
        }

        private void UserBetConfig(EntityTypeBuilder<UserBet> userBet)
        {
            userBet.ToTable("UserBets");
            userBet.Property(ub => ub.Id).HasColumnName("Id").HasColumnType("INT").ValueGeneratedOnAdd();
            userBet.HasKey(ub => ub.Id);

            userBet.Property(ub => ub.UserId).HasColumnName("UserId").HasColumnType("INT").ValueGeneratedOnAdd();
            userBet.Property(ub => ub.BookmakerBetId).HasColumnName("BookmakerBetId").HasColumnType("INT").ValueGeneratedOnAdd();
            
            userBet.Property(ub => ub.BetSum).HasColumnName("UserBetSum").HasColumnType("money");
            userBet.Property(ub => ub.PossibleWinSum).HasColumnName("UserBetPossibleWin").HasColumnType("money");
            userBet.Property(ub => ub.BetStatus).HasColumnName("BetStatus").HasColumnType("varchar(20)");
        }

        private void BookmakerBetConfig(EntityTypeBuilder<BookmakerBet> bookmakerBet)
        {
            bookmakerBet.ToTable("BookmakerBets");
            bookmakerBet.Property(bb => bb.Id).HasColumnName("Id").HasColumnType("INT").ValueGeneratedOnAdd();
            bookmakerBet.HasKey(bb => bb.Id);
            
            bookmakerBet.Property(bb => bb.BookmakerId).HasColumnName("UserId").HasColumnType("INT").ValueGeneratedOnAdd();
            bookmakerBet.Property(bb => bb.RaceParticipantBetId).HasColumnName("RaceParticipantBetId").HasColumnType("INT").ValueGeneratedOnAdd();

            bookmakerBet.Property(bb => bb.Coefficient).HasColumnName("Coefficient").HasColumnType("float");

            bookmakerBet.HasMany(bb => bb.UserBets).WithOne(ub => ub.BookmakerBet).HasForeignKey(ub => ub.BookmakerBetId);
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
            race.HasMany(r => r.RaceParticipants).WithOne(rp => rp.Race).HasForeignKey(rp => rp.RaceId).OnDelete(DeleteBehavior.Cascade);
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
            raceParticipant.HasMany(rp => rp.RaceParticipantBets).WithOne(rb => rb.RaceParticipant).HasForeignKey(rb => rb.RaceParticipantId).OnDelete(DeleteBehavior.Cascade);
        }

        private void RaceParticipantBetConfig(EntityTypeBuilder<RaceParticipantBet> raceParticipantBet)
        {
            raceParticipantBet.ToTable("RaceParticipantsBets");
            raceParticipantBet.Property(rb => rb.Id).HasColumnName("RaceParticipantBetId").HasColumnType("INT").ValueGeneratedOnAdd();
            raceParticipantBet.Property(rb => rb.RaceParticipantId).HasColumnName("RaceParticipantId").HasColumnType("INT").ValueGeneratedOnAdd();
            raceParticipantBet.HasKey(rb => rb.Id);
            raceParticipantBet.Property(rb => rb.RaceBetTypeId).HasColumnName("RaceBetType").HasColumnType("INT");
            raceParticipantBet.HasMany(rb => rb.BookmakerBets).WithOne(ub => ub.RaceParticipantBet).HasForeignKey(ub => ub.RaceParticipantBetId).OnDelete(DeleteBehavior.Cascade);
        }

        private void RaceBetTypeConfig(EntityTypeBuilder<RaceBetType> raceBetType)
        {
            raceBetType.ToTable("RaceBetType");
            raceBetType.Property(rbt => rbt.RaceBetTypeId).HasColumnName("RaceBetTypeId").HasColumnType("INT").ValueGeneratedOnAdd();
            raceBetType.Property(rbt => rbt.RaceBetTypeName).HasColumnName("RaceBetTypeName").HasColumnType("varchar(25)");
            raceBetType.HasAlternateKey(rbt => rbt.RaceBetTypeName);
            raceBetType.HasMany(rbt => rbt.RaceParticipantBets).WithOne(rpb => rpb.RaceBetType).HasForeignKey(rpb => rpb.RaceBetTypeId);
        }

        
    }
}
