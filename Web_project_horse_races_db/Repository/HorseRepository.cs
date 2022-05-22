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
    public class HorseRepository : IRepository<Horse>
    {
        public List<Horse> GetAll()
        {
            using ApplicationContext db = new ApplicationContext();
            return db.Horses.ToList();
        }

        public Horse GetOneById(int id)
        {
            using ApplicationContext db = new ApplicationContext();
            return db.Horses.Find(id);
        }

        public void Save(Horse horse)
        {
            using ApplicationContext db = new ApplicationContext();
            db.Horses.Add(horse);
            db.SaveChanges();
        }

        public void Update(Horse horse)
        {
            using ApplicationContext db = new ApplicationContext();
            db.Update(horse);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            using ApplicationContext db = new ApplicationContext();
            db.Remove(GetOneById(id));
            db.SaveChanges();
        }

        public void Delete(Horse horse)
        {
            using ApplicationContext db = new ApplicationContext();
            db.Remove(horse);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            using ApplicationContext db = new ApplicationContext();
            db.Remove(GetAll());
            db.SaveChanges();
        }
    }
}
