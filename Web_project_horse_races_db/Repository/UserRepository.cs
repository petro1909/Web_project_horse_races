using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_db.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Web_project_horse_races_db.Repository
{
    public class UserRepository : BaseUserRepository
    {
        public new List<User> GetAll()
        {
            using ApplicationContext db = new ApplicationContext();
            return db.Users.Include(u => u.Role).Include(u => u.UserBets).ToList();
        }

        public User GetOneById(int id)
        {
            using ApplicationContext db = new ApplicationContext();
            
            User user = db.Users.Find(id);
            user.Role = db.Roles.FirstOrDefault(ur => ur.Id == user.RoleId);
            user.UserBets = new UserBetRepository().GetRangeByUserId(id);
            return user;
        }

        public void Save(User user)
        {
            using ApplicationContext db = new ApplicationContext();
            //User u = new User() { Name = "u_name", Email = "u_email", Password = "u_password", RoleId = 3 };
            db.Users.Add(user);
            //db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Users ON;");
            db.SaveChanges();
            //db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT WEB_PROJECT_HORSE_RACES_test.Users OFF;");
        }

        public void Update(User user)
        {
            using ApplicationContext db = new ApplicationContext();
            db.Users.Update(user);
            db.SaveChanges();
        }

        public void ChangeUserBanState(int id)
        {
            User user = GetOneById(id);
            user.BanState = !user.BanState;
            Update(user);
        }

        public void AddUserBet(UserBet userBet)
        {
            UserBetRepository userBetRepositiory = new UserBetRepository();
            userBetRepositiory.Save(userBet);
        }

        public void Delete(int id)
        {
            using ApplicationContext db = new ApplicationContext();
            db.Users.Remove(GetOneById(id));
            db.SaveChanges();
        }

        public void Delete(User user)
        {
            using ApplicationContext db = new ApplicationContext();
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            using ApplicationContext db = new ApplicationContext();
            db.Users.RemoveRange(GetAll());
            db.SaveChanges();
        }
    }
}
