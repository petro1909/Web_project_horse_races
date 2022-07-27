using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_web.Services.Bets;
using Web_project_horse_races_db.EntityFramework;

namespace Web_project_horse_races_web.Services
{
    public class BetService
    {
        public void CalculateUserBetsOfEndedRace(Race race)
        {
            foreach(BookmakerRaceBet bbet in race.BookmakerRaceBets)
            {
                foreach(UserBet ubet in bbet.UserBets)
                {
                    //IBetService service = IBetService.CreateService(ubet.BetType.Name);
                    //service.CalculateBet(ubet);
                    //new UserService().UpdateUserMoneyBalanceByBetResult(ubet);
                }
            }
        }

        public List<BetType> GetAllBetTypes()
        {
            ApplicationContext db = new ApplicationContext();
            return db.BetTypes.ToList();
        }
    }
}
