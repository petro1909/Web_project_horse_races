using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.EntityFramework;
using Web_project_horse_races_db.Model;
using Microsoft.EntityFrameworkCore;

namespace Web_project_horse_races_web.Services
{
    public class RaceService
    {
        //public delegate void EndRaceDelegate(object sender, EventArgs e);
        //public event EndRaceDelegate RaceEnded;

        public List<Race> GetAllRaces()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Race> races = db.Races.Include(r => r.RaceParticipants).ThenInclude(rp => rp.Horse)
                    //Include(r => r.RaceParticipants).ThenInclude(rp => rp.RaceParticipantBets).ThenInclude(rpb => rpb.RaceBetType).
                    //Include(r => r.RaceParticipants).ThenInclude(rp => rp.RaceParticipantBets).ThenInclude(rpb => rpb.BookmakerBets).ThenInclude(bb => bb.Bookmaker)
                    .ToList();
                return races;
            }
        }

        public Race GetRaceById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Race race = db.Races.Include(r => r.RaceParticipants).ThenInclude(rp => rp.Horse).
                    //Include(r => r.RaceParticipants).ThenInclude(rp => rp.RaceParticipantBets).ThenInclude(rpb => rpb.RaceBetType).
                    //Include(r => r.RaceParticipants).ThenInclude(rp => rp.RaceParticipantBets).ThenInclude(rpb => rpb.BookmakerBets).ThenInclude(bb => bb.Bookmaker).
                    //Include(r => r.RaceParticipants).ThenInclude(rp => rp.RaceParticipantBets).ThenInclude(rpb => rpb.BookmakerBets).ThenInclude(bb => bb.UserBets).ThenInclude(ub => ub.User).
                    FirstOrDefault(r => r.Id == id);
                return race;
            }
        }


        public void CreateRace(Race race)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Races.Add(race);
                db.SaveChanges();
            }
        }

        public void UpdateRace(Race race)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Races.Update(race);
                db.SaveChanges();
            }
        }


        public void DeleteRace(Race race)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Races.Remove(race);
                db.SaveChanges();
            }
        }

        public void DeleteRace(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Race race = db.Races.Find(id);
                db.Races.Remove(race);
                db.SaveChanges();
            }
        }

        public void StartRace(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Race race = db.Races.Find(id);
                race.RaceStatus = RaceStatus.RUNNING;
                db.SaveChanges();
            }
        }
       
        public void EndRace(int raceId)
        {
            Race race = GetRaceById(raceId);
            race.RaceStatus = RaceStatus.ENDED;
            IEnumerable<int> randomNumbers = Enumerable.Range(1, race.RaceParticipants.Count);
            List<int> shuffledList = Shuffle(randomNumbers);
            
            for(int i = 0; i < race.RaceParticipants.Count; i++)
            {
                race.RaceParticipants[i].Position = (byte)shuffledList[i];
            }
            //new RaceRepository().Update(race);
            bubbleSort(race.RaceParticipants);
            new UserBetService().CalculateUserBet(race.RaceParticipants);
            //RaceEnded?.Invoke(race, new EventArgs());
        }
        void bubbleSort(List<RaceParticipant> arr) 
        {
            int n = arr.Count;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j].Position > arr[j + 1].Position)
                    {
                        // swap temp and arr[i]
                        RaceParticipant temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
        }
        public List<int> Shuffle(IEnumerable<int> list)
        {
            var r = new Random((int)DateTime.Now.Ticks);
            var shuffledList = list.Select(x => new { Number = r.Next(), Item = x }).OrderBy(x => x.Number).Select(x => x.Item);
            return shuffledList.ToList();
        }




        //public List<RaceBetType> GetRaceBetTypes()
        //{
        //    using (ApplicationContext db = new ApplicationContext())
        //    {
        //        return db.RaceBetTypes.ToList();
        //    }
        //}



        //public RaceParticipantBet GetOneRPBById(int id)
        //{
        //    using (ApplicationContext db = new ApplicationContext())
        //    {
        //        return db.RaceBets.Include(rb => rb.BookmakerBets).FirstOrDefault(rb => rb.Id == id);
        //    }
        //}
    }
}
