using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_project_horse_races_db.EntityFramework;
using Web_project_horse_races_db.Model;

namespace Web_project_horse_races_db.Repository
{
    public class RaceParticipantRepository : IRepository<RaceParticipant>
    {
        public List<RaceParticipant> GetAll()
        {
            using ApplicationContext db = new ApplicationContext();
            return db.RaceParticipants.Include(rp => rp.Horse).ToList();
        }

        public RaceParticipant GetOneById(int id)
        {
            using ApplicationContext db = new ApplicationContext();
            RaceParticipant raceParticipant = db.RaceParticipants.Find(id);
            raceParticipant.Horse = db.Horses.Find(raceParticipant.HorseId);
            raceParticipant.Race = db.Races.Find(raceParticipant.RaceId);
            return raceParticipant;
        }

        public void Save(RaceParticipant raceParticipant)
        {
            using ApplicationContext db = new ApplicationContext();
            db.RaceParticipants.Add(raceParticipant);
            db.SaveChanges();
        }

        public void SaveRange(List<RaceParticipant> raceParticipants)
        {
            using ApplicationContext db = new ApplicationContext();
            db.RaceParticipants.AddRange(raceParticipants);
            db.SaveChanges();
        }

        public void Update(RaceParticipant raceParticipant)
        {
            using ApplicationContext db = new ApplicationContext();
            db.RaceParticipants.Update(raceParticipant);
            db.SaveChanges();
        }

        public void SetRaceParticipantNumber(RaceParticipant raceParticipant, byte number)
        {
            using ApplicationContext db = new ApplicationContext();
            raceParticipant.Number = number;
            db.SaveChanges();
        }

        public void SetRaceParticipantPosition(RaceParticipant raceParticipant, byte position)
        {
            using ApplicationContext db = new ApplicationContext();
            raceParticipant.Position = position;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            using ApplicationContext db = new ApplicationContext();
            db.RaceParticipants.Remove(GetOneById(id));
            db.SaveChanges();
        }

        public void Delete(RaceParticipant raceParticipant)
        {
            using ApplicationContext db = new ApplicationContext();
            db.RaceParticipants.Remove(raceParticipant);
            db.SaveChanges();
        }

        public void DeleteRange(List<RaceParticipant> raceParticipants)
        {
            using ApplicationContext db = new ApplicationContext();
            db.RaceParticipants.RemoveRange(raceParticipants);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            using ApplicationContext db = new ApplicationContext();
            db.RaceParticipants.RemoveRange(GetAll());
            db.SaveChanges();
        }
    }
}
