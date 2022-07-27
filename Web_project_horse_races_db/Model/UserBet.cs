using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_project_horse_races_db.Model
{
    public enum BetStatus
    {
        WAITING,
        PASSED,
        NOTPASSED
    }

    public class UserBet
    {
        public int Id { get; }
        public int UserId { set; get; }
        public User User { set; get; }
        public int BookmakerRaceBetId { set; get; }
        public BookmakerRaceBet BookmakerRaceBet { set; get; }
        public List<BookmakerBet> BookmakerBets { set; get; }
        public double Coefficient { set; get; }
        public decimal BetSum { set; get; }
        public decimal PossibleWinSum { set; get; }
        public BetStatus BetStatus { set; get; }

    }
}
