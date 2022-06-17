using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_project_horse_races_db.Model
{
    public class UserBetType
    {
       public int Id { get; }
       public string Name { set; get; }
       public List<UserBet> UserBets { set; get; }
    }
}
