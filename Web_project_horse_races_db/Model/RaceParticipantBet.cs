using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_project_horse_races_db.Model
{
    public class RaceParticipantBet
    {
        public int Id { set; get; }
        public int RaceParticipantId { set; get; }
        public RaceParticipant RaceParticipant { set; get; }
        public int BetTypeId { set; get; }
        public BetType BetType { set; get; }


        public List<BookmakerBet> BookmakerBets { set; get; }

        public RaceParticipantBet()
        {
        }

    }
}
