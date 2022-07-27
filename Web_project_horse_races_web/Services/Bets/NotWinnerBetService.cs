using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;

namespace Web_project_horse_races_web.Services.Bets
{
    public class NotWinnerBetService : IBetService
    {
        public bool CalculateBet(UserBet bet)
        {
            //foreach(BookmakerBet bbet in bet.BookmakerBets)
            //{
            //    if(bbet.RaceParticipant.Position == 1)
            //    {
            //        return false;
            //    }
            //}
            return true;
        }

        public double CalculateBetCoefficient(List<BookmakerBet> bbets)
        {
            double coefficient = 0;
            foreach (BookmakerBet bet in bbets)
            {
                coefficient += 1 / (1 - (1 / bet.Coefficient));
            }
            return coefficient / bbets.Count;
        }
    }
}
