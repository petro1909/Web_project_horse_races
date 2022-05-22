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
    public class RaceRepository : IRepository<Race>
    {
        public List<Race> GetAll()
        {
            using ApplicationContext db = new ApplicationContext();
            List<Race> races = db.Races.Include(r => r.RaceBets).ToList();
            foreach(Race race in races)
            {
                race.RaceParticipants = db.RaceParticipants.Include(rp => rp.Horse).Where(rp => rp.RaceId == race.Id).ToList();
            }
            return races;
        }

        public Race GetOneById(int id)
        {
            using ApplicationContext db = new ApplicationContext();
            Race race = db.Races.Find(id);
            race.RaceParticipants = db.RaceParticipants.Include(rp => rp.Horse).Where(rp => rp.RaceId == race.Id).ToList();
            race.RaceBets = db.RaceBets.Where(rb => rb.RaceId == id).ToList();
            return race;
        }

        public void Save(Race race)
        {
            using ApplicationContext db = new ApplicationContext();
            db.Races.Add(race);
            db.SaveChanges();
        }

        public void AddRaceParticipants(List<RaceParticipant> raceParticipants)
        {
            foreach (RaceParticipant raceParticipant in raceParticipants)
            {
                AddRaceParticipant(raceParticipant);
            }
        }
        public void AddRaceParticipant(RaceParticipant raceParticipant)
        {
            RaceParticipantRepository raceParticipantRepository = new RaceParticipantRepository();
            raceParticipantRepository.Save(raceParticipant);

            RaceBet raceBet = new RaceBet() { RaceId = raceParticipant.RaceId, RaceParicipantId = raceParticipant.Id };
            AddRaceBet(raceBet);
        }

        public void AddRaceBet(RaceBet raceBet)
        {
            RaceBetRepository raceBetRepository = new RaceBetRepository();
            raceBetRepository.Save(raceBet);
        } 

        public void Update(Race race)
        {
            using ApplicationContext db = new ApplicationContext();
            db.Races.Update(race);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            using ApplicationContext db = new ApplicationContext();
            db.Races.Remove(GetOneById(id));
            db.SaveChanges();
        }

        public void Delete(Race race)
        {
            using ApplicationContext db = new ApplicationContext();
            db.Races.Remove(race);
            db.SaveChanges();
        }


        public void DeleteParticipant(RaceParticipant raceParticipant)
        {
            RaceParticipantRepository raceParticipantRepository = new RaceParticipantRepository();
            raceParticipantRepository.Delete(raceParticipant);
        }

        public void DeleteParticipants(Race race)
        {
            RaceParticipantRepository raceParticipantRepository = new RaceParticipantRepository();
            raceParticipantRepository.DeleteRange(race.RaceParticipants);
        }

        public void DeleteAll()
        {
            using ApplicationContext db = new ApplicationContext();
            db.Races.RemoveRange(GetAll());
            db.SaveChanges();
        }
    }
}
