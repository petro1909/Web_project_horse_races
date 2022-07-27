using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.EntityFramework;
using Web_project_horse_races_db.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Web_project_horse_races_web.Services
{
    public class UserService
    {
        public void UpdateUserMoneyBalanceByBetResult(UserBet ubet)
        {
            if(ubet.BetStatus == BetStatus.PASSED)
            {
                ubet.User.MoneyBalance += ubet.PossibleWinSum;
            }
        }

        public int GetUserBetCount(User user)
        {
            return user.UserBets.Count;
        }

        public int GetUserSpecifiedBetCount(User user, BetStatus status)
        {
            return user.UserBets.Count(ub => ub.BetStatus == status);
        }


        public string GetUserType(ClaimsPrincipal user)
        {
            if (user.Claims.Count() == 0)
            {
                return string.Empty;
            }

            string type = user.FindFirst(u => u.Type == "type").Value;
            if (type == "bookmaker")
            {
                return "BOOKMAKER";
            }
            else
            {
                return user.FindFirst(u => u.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            }
        }
    }
}
