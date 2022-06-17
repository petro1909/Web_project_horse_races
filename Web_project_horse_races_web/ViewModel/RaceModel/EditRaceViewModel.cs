using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_web.Services;

namespace Web_project_horse_races_web.ViewModel.RaceModel
{
    public class EditRaceViewModel
    {
        public Race Race { set; get; }
        public List<Horse> Horses { set; get; }

        public EditRaceViewModel(Race race)
        {
            this.Race = race;
            Horses = new HorseService().GetAllHorses();
        }
       
    }
}
