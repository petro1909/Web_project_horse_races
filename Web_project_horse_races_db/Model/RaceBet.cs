using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_project_horse_races_db.Model
{
    public class RaceBet
    {
        public int Id { set; get; }
        public int RaceId { set; get; }
        public Race Race { set; get; }

        public int RaceParicipantId { set; get; }
        public RaceParticipant RaceParticipant { set; get; }

        public List<UserBet> UserBets { set; get; }

        public double Coefficient { set; get; }
        public decimal TotalSum { set; get; }
        public int UserBetCount { set; get; }

        public RaceBet()
        {
            Coefficient = 1;
        }

    }
}
