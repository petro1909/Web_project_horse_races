using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_project_horse_races_db.Model
{
    public class BookmakerRaceBet
    {
        public int Id { get; }
        public string BookmakerName { set; get; }
        public Bookmaker Bookmaker { set; get; }
        public int RaceId { set; get; }
        public Race Race { set; get; }
        public List<BookmakerBet> BookmakerBets { set; get; }
        public List<UserBet> UserBets { set; get; }

        public BookmakerRaceBet()
        {
            BookmakerBets = new List<BookmakerBet>();
            UserBets = new List<UserBet>();
        }

    }
}
