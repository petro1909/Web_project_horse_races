using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;

namespace Web_project_horse_races_web.Services.Bets
{
    public class PlaceBetService : IBetService
    {
        public bool CalculateBet(UserBet bet)
        {
            BookmakerBet bbet = bet.BookmakerBets.First();
            int prizePlaceCount = bet.BookmakerRaceBet.Race.PrizePlaceCount;
            if(bbet.RaceParticipantBet.RaceParticipant.Position <= prizePlaceCount)
            {
                return true;
            }
            return false;
        }

        public double CalculateBetCoefficient(List<BookmakerBet> bbets)
        {
            BookmakerBet bbet = bbets.First();
            int prizePlaceCount = bbet.BookmakerRaceBet.Race.PrizePlaceCount;
            int rpcount = bbet.BookmakerRaceBet.Race.RaceParticipants.Count;
            double coefficient = bbet.Coefficient * ((rpcount - prizePlaceCount)/rpcount);
            return coefficient;
        }
    }
}
