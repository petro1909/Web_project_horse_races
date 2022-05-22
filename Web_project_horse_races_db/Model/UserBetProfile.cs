using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_project_horse_races_db.Model
{
    public class UserBetProfile
    {
        public int UserId { set; get; }
        public User User { set; get; }
        public decimal MoneyBalance { set; get; }
        public int BetCount { set; get; }
        public int WinBets { set; get; }
        public int LooseBets { set; get; }
        public List<UserBet> UserBets { set; get; }

 
        public UserBetProfile()
        {
            MoneyBalance = 0;
            BetCount = 0;
            WinBets = 0;
            LooseBets = 0;
            UserBets = new List<UserBet>();
        }

        public override string ToString()
        {
            return "User Bet Profile [\n" +
                $"MoneyBalance : {MoneyBalance}\n" +
                $"Bet Count : {BetCount}\n" +
                $"Win Bets : {WinBets}\n" +
                $"Loose Bets : {LooseBets}";
        }
    }
}
