using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_project_horse_races_db.Model
{
    public class Bookmaker
    {
        public string Name { set; get; }
        public string Password { set; get; }
        public decimal MoneyBalance { set; get; }
        public List<BookmakerRaceBet> BookmakerRaceBets { set; get; }

        public Bookmaker() { }

        public Bookmaker(string name, string password)
        {
            Name = name;
            Password = password;
            BookmakerRaceBets = new List<BookmakerRaceBet>();
        }


    }
}
