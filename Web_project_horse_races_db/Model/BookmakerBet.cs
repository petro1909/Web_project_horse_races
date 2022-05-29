using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_project_horse_races_db.Model
{
    public class BookmakerBet : BaseBet
    {
        public int BookmakerId { set; get; }
        public Bookmaker Bookmaker { set; get; }
        public int RaceParticipantBetId { set; get; }
        public RaceParticipantBet RaceParticipantBet { set; get; }
        public List<UserBet> UserBets { set; get; }
        public double Coefficient { set; get; }

    }
}
