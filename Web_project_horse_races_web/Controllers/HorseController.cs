using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.EntityFramework;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_db.Repository;

namespace Web_project_horse_races_web.Controllers
{
    public class HorseController : Controller
    {
        HorseRepository horseRepository;
        public HorseController()
        {
            horseRepository = new HorseRepository();
        }
        public IActionResult Index()
        {
            List<Horse> horses = horseRepository.GetAll();
            return View(horses);
        }
        [HttpPost]
        public IActionResult Create(Horse horse)
        {
            horseRepository.Save(horse);
            return LocalRedirect("~/Horse/Index");
        }

        [HttpPost]
        public IActionResult Update(Horse horse)
        {
            horseRepository.Update(horse);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(Horse horse)
        {
            horseRepository.Delete(horse);
            return LocalRedirect("~/Horse/Index");
        }
    }
}
