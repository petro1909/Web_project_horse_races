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
    public class UserRepository :  IRepository<User>
    {
        public List<User> GetAll()
        {
            using ApplicationContext db = new ApplicationContext();
            return db.Users.Include(u => u.UserBetProfile).ToList();
        }

        public User GetOneById(int id)
        {
            using ApplicationContext db = new ApplicationContext();
            User user = db.Users.Find(id);
            user.UserBetProfile = db.UserBetProfiles.Find(user.Id);
            user.UserBetProfile.UserBets = db.UserBets.Where(ub =>ub.UserBetProfileId == user.Id).ToList();
            return user;
        }

        public User GetOneByLoginAndPassword(string login, string password)
        {
            using ApplicationContext db = new ApplicationContext();
            User user = db.Users.FirstOrDefault(u => u.Email == login && u.Password == password);
            return user;
        }


        public void Save(User user)
        {
            using ApplicationContext db = new ApplicationContext();
            db.Users.Add(user);
            try
            {
                db.SaveChanges();
            } catch(DbUpdateException e)
            {
                Console.WriteLine("User with the same email already exist");
            }
        }

        public void Update(User user)
        {
            using ApplicationContext db = new ApplicationContext();
            db.Users.Update(user);
            db.UserBetProfiles.Update(user.UserBetProfile);
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
            UserBetRepositiory userBetRepositiory = new UserBetRepositiory();
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
