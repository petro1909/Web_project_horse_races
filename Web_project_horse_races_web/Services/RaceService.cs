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
        public void GetBookmakerCoef(RaceParticipant participant, BetType btype)
        {

        }





        public void EndRace(Race race)
        {
            RandomRaceParticipantPositions(race.RaceParticipants);
        }


        private void RandomRaceParticipantPositions(List<RaceParticipant> participants)
        {
            for(int i = 0; i < participants.Count; i++)
            {
                participants[i].Position = (byte)(i + 1);
            }
            bubbleSort(participants);
        }

        private void bubbleSort(List<RaceParticipant> arr) 
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
