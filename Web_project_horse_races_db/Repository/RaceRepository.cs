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
            List<Race> races = db.Races.ToList();
            foreach(Race race in races)
            {
                race.RaceParticipants = db.RaceParticipants.Include(rp => rp.Horse).Where(rp => rp.RaceId == race.Id).ToList();
                foreach (RaceParticipant raceParticipant in race.RaceParticipants)
                {
                    raceParticipant.RaceParticipantBets = db.RaceBets.Where(rpb => rpb.RaceParticipantId == raceParticipant.Id).ToList();
                    foreach(RaceParticipantBet bet in raceParticipant.RaceParticipantBets)
                    {
                        bet.RaceBetType = db.RaceBetTypes.Find(bet.RaceBetTypeId);
                    }
                } 
            }
            return races;
        }

        public Race GetOneById(int id)
        {
            using ApplicationContext db = new ApplicationContext();
            Race race = db.Races.Find(id);
            race.RaceParticipants = db.RaceParticipants.Include(rp => rp.Horse).Where(rp => rp.RaceId == race.Id).ToList();
            foreach (RaceParticipant raceParticipant in race.RaceParticipants)
            {
                raceParticipant.RaceParticipantBets = db.RaceBets.Where(rpb => rpb.RaceParticipantId == raceParticipant.Id).ToList();
                foreach (RaceParticipantBet bet in raceParticipant.RaceParticipantBets)
                {
                    bet.RaceBetType = db.RaceBetTypes.Find(bet.RaceBetTypeId);
                    bet.BookmakerBets = db.BookmakerBets.Where(bb => bb.RaceParticipantBetId == bet.Id).ToList();
                    foreach(BookmakerBet bookmakerBet in bet.BookmakerBets)
                    {
                        bookmakerBet.Bookmaker = db.Bookmakers.Find(bookmakerBet.BookmakerId);
                    }
                }
            }
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

            RaceParticipantBet raceBet = new RaceParticipantBet() { RaceParticipantId = raceParticipant.Id};
            AddRaceBet(raceBet);
        }

        public void AddRaceBet(RaceParticipantBet raceBet)
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
