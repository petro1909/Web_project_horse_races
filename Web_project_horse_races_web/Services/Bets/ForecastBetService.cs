using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;

namespace Web_project_horse_races_web.Services.Bets
{
    public class ForecastBetService : IBetService
    {
        public bool CalculateBet(UserBet bet)
        {
            //RaceParticipant first = bet.BookmakerBets[0].RaceParticipant;
            //RaceParticipant second = bet.BookmakerBets[1].RaceParticipant;
            //if(first.Position == 1 && second.Position == 2)
            //{
            //    return true;
            //}
            return false;
        }

        public double CalculateBetCoefficient(List<BookmakerBet> bbets)
        {
            int rpcount = bbets.First().BookmakerRaceBet.Race.RaceParticipants.Count;
            double coefficient = 0;
            for (int i = 0; i < bbets.Count; i++)
            {
                coefficient += bbets[i].Coefficient * ((rpcount - i + 1) / rpcount);
            }
            return coefficient / bbets.Count;
        }
    }
}
