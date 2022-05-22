using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_project_horse_races_db.Model
{
    public class UserBet
    {
        //public int Id { set; get; }
        public int UserBetProfileId { set; get; }
        public UserBetProfile UserBetProfile { set; get; }
        public int RaceBetId {set; get; }
        public RaceBet RaceBet { set; get; }
        public decimal BetSum { set; get; }
        public double coefficient { set; get; }
        public decimal PossibleWinSum { set; get; }
        //bool? BetStatus { set; get; }
    }
}
