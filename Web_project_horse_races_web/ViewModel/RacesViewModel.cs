using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;

namespace Web_project_horse_races_web.ViewModel
{
    public class RacesViewModel
    {
        public List<RaceViewModel> racesViewModel;
        public RacesViewModel(List<Race> races)
        {
            racesViewModel = GetRacesViewModel(races);
        }

        private List<RaceViewModel> GetRacesViewModel(List<Race> races)
        {
            List<RaceViewModel> raceViewModels = new List<RaceViewModel>();
            foreach(Race race in races)
            {
                raceViewModels.Add(new RaceViewModel(race));
            }
            return raceViewModels;
        }
    }
}
