using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;

namespace Web_project_horse_races_web.Services.Bets
{
    public class WinnerBetService : IBetService
    {
        public bool CalculateBet(UserBet ubet)
        {
            //foreach(BookmakerBet bet in ubet.BookmakerBets)
            //{
            //    if(bet.RaceParticipant.Position == 1)
            //    {
            //        return true;
            //    }
            //}
            return false;
        }

        public double CalculateBetCoefficient(List<BookmakerBet> bbets)
        {
            double coefficient = 0;
            foreach(BookmakerBet bet in bbets)
            {
                coefficient += bet.Coefficient;
            }
            return coefficient / bbets.Count;
        }


    }
}
