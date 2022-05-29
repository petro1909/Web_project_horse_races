using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_db.Repository;

namespace Web_project_horse_races_web.ViewModel
{
    public class RaceViewModel
    {
        public Race race;
        public Dictionary<RaceBetType, List<RaceParticipantBet>> raceParticipantsByBetType;
        public RaceViewModel(Race race)
        {
            this.race = race;
            raceParticipantsByBetType = GetRaceParticipantsByBetType(race);
        }


        private Dictionary<RaceBetType, List<RaceParticipantBet>> GetRaceParticipantsByBetType(Race race)
        {
            Dictionary<RaceBetType, List<RaceParticipantBet>> participants = new Dictionary<RaceBetType, List<RaceParticipantBet>>();
            
            BetTypeRepository betTypeRepository = new BetTypeRepository();
            List<RaceBetType> raceBetTypes = betTypeRepository.GetAll();
            
            foreach(RaceBetType raceBetType in raceBetTypes)
            {
                participants.Add(raceBetType, new List<RaceParticipantBet>());
            }

            foreach (RaceParticipant raceParticipant in race.RaceParticipants)
            {
                foreach (RaceParticipantBet bet in raceParticipant.RaceParticipantBets) 
                {   
                    foreach (RaceBetType raceBetType in participants.Keys)
                    {
                        if (bet.RaceBetType.RaceBetTypeName == raceBetType.RaceBetTypeName)
                        {
                            participants[raceBetType].Add(bet);
                        }
                    } 
                }
            }
            return participants;
        }




    }
}
