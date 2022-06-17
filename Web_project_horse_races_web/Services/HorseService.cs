using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_db.EntityFramework;
using Microsoft.EntityFrameworkCore;
namespace Web_project_horse_races_web.Services
{
    public class HorseService
    {
        public List<Horse> GetAllHorses()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Horses.Include(h => h.RaceParticipants).ThenInclude(rp => rp.Race).ToList();
            }
        }


        public Horse GetHorseById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Horse horse = db.Horses.Include(h => h.RaceParticipants).ThenInclude(rp => rp.Race).FirstOrDefault(h => h.Id == id);
                return horse;
            }
        }

        public void UpdateHorse(Horse horse)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Horses.Update(horse);
                db.SaveChanges();
            }
        }
    }
}
