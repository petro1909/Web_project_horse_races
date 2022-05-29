using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_project_horse_races_db.EntityFramework;
using Web_project_horse_races_db.Model;

namespace Web_project_horse_races_db.Repository
{
    public class RaceBetRepository : IRepository<RaceParticipantBet>
    {
        public List<RaceParticipantBet> GetAll()
        {
            using ApplicationContext db = new ApplicationContext();
            return db.RaceBets.ToList();
        }

        public RaceParticipantBet GetOneById(int id)
        {
            using ApplicationContext db = new ApplicationContext();
            RaceParticipantBet raceParticipantBet = db.RaceBets.Find(id);
            raceParticipantBet.RaceBetType = db.RaceBetTypes.Find(raceParticipantBet.RaceBetTypeId);
            raceParticipantBet.RaceParticipant = new RaceParticipantRepository().GetOneById(raceParticipantBet.RaceParticipantId);
            return raceParticipantBet;
        }

        public void Save(RaceParticipantBet raceBet)
        {
            using ApplicationContext db = new ApplicationContext();
            db.RaceBets.Add(raceBet);
            db.SaveChanges();
        }

        public void Update(RaceParticipantBet raceBet)
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

        public void Delete(RaceParticipantBet raceBet)
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
