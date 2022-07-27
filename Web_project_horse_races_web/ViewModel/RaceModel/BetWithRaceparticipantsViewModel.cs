using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;

namespace Web_project_horse_races_web.ViewModel.RaceModel
{
    public class BetWithRaceparticipantsViewModel
    {
        public List<RaceParticipantBet> BetParticipants;
        public BetType BetType;
        public BetWithRaceparticipantsViewModel(BetType btype, List<RaceParticipantBet> betParticipants)
        {
            this.BetType = btype;
            this.BetParticipants = betParticipants;
           // this.bbetsVM = GetRPBookmakersBetVM(btype);
        }

        //public List<BookmakerBetViewModel> GetRPBookmakersBetVM(BetType btype)
        //{
        //    List<BookmakerBetViewModel> bbets = new List<BookmakerBetViewModel>();

        //    foreach(BookmakerBet bet in participant.BookmakerBets)
        //    {
        //        bbets.Add(new BookmakerBetViewModel(bet, btype));
        //    }
        //    return bbets;
        //}

        


    }
}
