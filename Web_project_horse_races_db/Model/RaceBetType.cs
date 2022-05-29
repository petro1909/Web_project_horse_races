using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_project_horse_races_db.Model
{
    public class RaceBetType
    {
       public int RaceBetTypeId { set; get; }
       public string RaceBetTypeName { set; get; }
       public List<RaceParticipantBet> RaceParticipantBets { set; get; }
    }
}
