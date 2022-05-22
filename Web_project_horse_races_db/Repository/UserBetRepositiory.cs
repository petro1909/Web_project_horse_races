using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_project_horse_races_db.EntityFramework;
using Web_project_horse_races_db.Model;

namespace Web_project_horse_races_db.Repository
{
    class UserBetRepositiory : IRepository<UserBet>
    {
        public List<UserBet> GetAll()
        {
            using ApplicationContext db = new ApplicationContext();
            return db.UserBets.ToList();
        }

        public UserBet GetOneById(int id)
        {
            using ApplicationContext db = new ApplicationContext();
            return db.UserBets.Find(id);
        }

        public void Save(UserBet userBet)
        {
            using ApplicationContext db = new ApplicationContext();
            db.UserBets.Add(userBet);
            db.SaveChanges();
        }

        public void Update(UserBet userBet)
        {
            using ApplicationContext db = new ApplicationContext();
            db.UserBets.Update(userBet);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            using ApplicationContext db = new ApplicationContext();
            db.UserBets.Remove(GetOneById(id));
            db.SaveChanges();
        }

        public void Delete(UserBet userBet)
        {
            using ApplicationContext db = new ApplicationContext();
            db.UserBets.Remove(userBet);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            using ApplicationContext db = new ApplicationContext();
            db.UserBets.RemoveRange(GetAll());
            db.SaveChanges();
        }
    }
}
