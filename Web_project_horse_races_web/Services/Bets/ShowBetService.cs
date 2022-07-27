using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;

namespace Web_project_horse_races_web.Services.Bets
{
    public class ShowBetService : IBetService
    {
        public bool CalculateBet(UserBet bet)
        {
            //BookmakerBet bbet = bet.BookmakerBets.First();
            //if(bbet.RaceParticipant.Position <= 3)
            //{
            //    return true;
            //}
            return false;
        }

        public double CalculateBetCoefficient(List<BookmakerBet> bbets)
        {
            BookmakerBet bet = bbets.First();
            int rpcount = bet.BookmakerRaceBet.Race.RaceParticipants.Count;
            double coefficient = bet.Coefficient * ((rpcount - 3) / rpcount);
            return coefficient;
        }
    }
}
