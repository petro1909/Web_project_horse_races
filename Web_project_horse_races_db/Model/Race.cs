using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_project_horse_races_db.Model
{
    public enum RaceStatus {
        EXPECTED,
        RUNNING,
        ENDED
    }
    public class Race
    {
        public int Id { set; get; }
        public DateTime RaceDate { set; get; }
        public List<RaceParticipant> RaceParticipants { set; get; }
        public RaceParticipant RaceWinner { set; get; }
        public List<RaceBet> RaceBets { set; get; }
        public RaceStatus RaceStatus { set; get; }
        
        public Race() { }
        public Race(DateTime raceDate)
        {
            this.RaceDate = raceDate;
            this.RaceParticipants = new List<RaceParticipant>();
        }

        public Race(DateTime raceDate, List<RaceParticipant> raceParticipants)
        {
            this.RaceDate = raceDate;
            this.RaceParticipants = raceParticipants;
        }


    }
}
