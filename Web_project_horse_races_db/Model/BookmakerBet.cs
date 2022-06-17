using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_project_horse_races_db.Model
{
    public class BookmakerBet
    {
        public int Id { get; }
        public int BookmakerRaceBetId { set; get; }
        public BookmakerRaceBet BookmakerRaceBet { set; get; }
        public List<UserBet> UserBets { set; get; }
        public int RaceParticipantId { set; get; }
        public RaceParticipant RaceParticipant { set; get; }
        public double Coefficient { set; get; }
    }
}
