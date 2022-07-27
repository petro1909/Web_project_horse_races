using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_db.EntityFramework;
using Web_project_horse_races_web.Services;

namespace Web_project_horse_races_web.ViewModel.RaceModel
{
    public class RaceViewModel
    {
        public Race race;
        public List<BetWithRaceparticipantsViewModel> BetsWithParticipantsList;
        public RaceViewModel(Race race)
        {
            this.race = race;
            BetsWithParticipantsList = GetRaceParticipantsByBetType(race);
        }

        private List<BetWithRaceparticipantsViewModel> GetRaceParticipantsByBetType(Race race)
        {
            List<BetType> betTypes = new BetService().GetAllBetTypes();
            List<BetWithRaceparticipantsViewModel> participantsByBetType = new List<BetWithRaceparticipantsViewModel>();

            foreach (BetType raceBetType in betTypes)
            {
                List<RaceParticipantBet> betParticipants = new List<RaceParticipantBet>(race.RaceParticipants.Count);
                foreach (RaceParticipant participant in race.RaceParticipants)
                {
                    betParticipants.Add(participant.BetTypes.Single(rpbt => rpbt.BetType.Name == raceBetType.Name));
                }
                participantsByBetType.Add(new BetWithRaceparticipantsViewModel(raceBetType, betParticipants));
            }
            return participantsByBetType;
        }


    }
}
