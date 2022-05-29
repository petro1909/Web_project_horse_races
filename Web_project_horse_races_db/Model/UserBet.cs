using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_project_horse_races_db.Model
{
    public enum BetStatus
    {
        PASSED,
        NOTPASSED,
        WAITING
    }
    public class UserBet : BaseBet
    {
        public int UserId { set; get; }
        public User User { set; get; }

        public int BookmakerBetId { set; get; }
        public BookmakerBet BookmakerBet { set; get; }

        public decimal BetSum { set; get; }
        public decimal PossibleWinSum { set; get; }

        public BetStatus BetStatus { set; get; }
    }
}
