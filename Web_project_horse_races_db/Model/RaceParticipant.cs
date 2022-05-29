using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_project_horse_races_db.Model
{
    public class RaceParticipant
    {
       public int Id { set; get; }
       public int RaceId { set; get; }
       public Race Race { set; get; }

       public int HorseId { set; get; }
       public Horse Horse { set; get; }

        public byte Number { set; get; }
        public byte Position { set; get; }

        public List<RaceParticipantBet> RaceParticipantBets { set; get; }

        public RaceParticipant()
        {

        }
        public RaceParticipant(byte number)
        {
            Number = number;
            Position = 0;
        }

        public override string ToString()
        {
            return $"RaceParticipant [\n " +
                   $"RaceId : {RaceId}\n " +
                   $"HorseId : {HorseId}\n " +
                    $"Number : {Number}\n " +
                    $"Position : {Position}\n]";
        }
    }
}
