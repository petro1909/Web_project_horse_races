using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;

namespace Web_project_horse_races_web.Services
{
    public class UserBetService
    {
        public void CalculateUserBet(List<RaceParticipant> raceParticipants)
        {
            foreach(RaceParticipant raceParticipant in raceParticipants)
            {
                //foreach(RaceParticipantBet bet in raceParticipant.RaceParticipantBets)
                //{
                //    List<BookmakerBet> bookmakerBets = bet.BookmakerBets;
                //    foreach(BookmakerBet bookmakerBet in bookmakerBets)
                //    {
                //        List<UserBet> userBets = bookmakerBet.UserBets;
                //        for(int i = 0; i< userBets.Count; i++)
                //        {
                //            UserBet userBet = userBets[i];
                //            if ((bet.RaceBetType.RaceBetTypeName == "WINNER" && raceParticipant.Position == 1) ||
                //                (bet.RaceBetType.RaceBetTypeName == "DOUBLE" && (raceParticipant.Position == 1 || raceParticipant.Position == 2)) ||
                //                (bet.RaceBetType.RaceBetTypeName == "TRIPPLE" && (raceParticipant.Position == 1 || raceParticipant.Position == 2 || raceParticipant.Position == 3)))
                //            {
                //                userBet.BetStatus = BetStatus.PASSED;
                //                userBet.User.WinBets += 1;
                //                userBet.User.MoneyBalance += userBet.PossibleWinSum;
                //            }
                //            else
                //            {
                //                userBet.BetStatus = BetStatus.NOTPASSED;
                //                userBet.User.LooseBets += 1;
                //            }
                //            userBet.User.BetCount += 1;
                //            new UserService().UpdateUserBet(userBet);
                //        }
                //    }
                //}
            }
        }
    }
}
