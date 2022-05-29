using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_project_horse_races_db.Model
{
    public class Bookmaker : BaseUser
    {
        public decimal MoneyBalance { set; get; }
        public List<BookmakerBet> BookmakerBets { set; get; }

        public Bookmaker() { }

        public Bookmaker(string name, string email, string password) : base(name, email, password)
        {
            BookmakerBets = new List<BookmakerBet>();
        }
    }
}
