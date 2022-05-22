using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_project_horse_races_db.EntityFramework;
using Web_project_horse_races_db.Model;

namespace Web_project_horse_races_db.Repository
{
    public class RaceBetRepository : IRepository<RaceBet>
    {
        public List<RaceBet> GetAll()
        {
            using ApplicationContext db = new ApplicationContext();
            return db.RaceBets.ToList();
        }

        public RaceBet GetOneById(int id)
        {
            using ApplicationContext db = new ApplicationContext();
            return db.RaceBets.Find(id);
        }

        public void Save(RaceBet raceBet)
        {
            using ApplicationContext db = new ApplicationContext();
            db.RaceBets.Add(raceBet);
            db.SaveChanges();
        }

        public void Update(RaceBet raceBet)
        {
            using ApplicationContext db = new ApplicationContext();
            db.RaceBets.Update(raceBet);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            using ApplicationContext db = new ApplicationContext();
            db.RaceBets.Remove(GetOneById(id));
            db.SaveChanges();
        }

        public void Delete(RaceBet raceBet)
        {
            using ApplicationContext db = new ApplicationContext();
            db.RaceBets.Remove(raceBet);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            using ApplicationContext db = new ApplicationContext();
            db.RaceBets.RemoveRange(GetAll());
            db.SaveChanges();
        }
    }
}
