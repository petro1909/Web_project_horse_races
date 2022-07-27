using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_web.Services.Bets;
using Web_project_horse_races_db.Model;

namespace Web_project_horse_races_web.ViewModel.RaceModel
{
    public class BookmakerBetViewModel
    {
        public BookmakerBet Bbet { set; get; }
        public string BookmakerName { set; get; }
        public double Coefficient { set; get; }
        public BookmakerBetViewModel(BookmakerBet bbet, BetType btype)
        {
            Bbet = bbet;
            Coefficient = GetCoefficient(btype);
        }

        private double GetCoefficient(BetType btype)
        {
            IBetService service = IBetService.CreateService(btype.Name);
            return service.CalculateBetCoefficient(new List<BookmakerBet>() {Bbet});
        }
    }
}
