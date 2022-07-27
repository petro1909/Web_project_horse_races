using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_project_horse_races_db.Model
{
    public class BetType
    {
       public int Id { get; }
       public string Name { set; get; }
       public List<RaceParticipantBet> RaceParticipantsBets { set; get; }

        public override bool Equals(object obj)
        {
            //if (!(obj is UserBetType type)) return false;
            return true;
        }
    }
}
