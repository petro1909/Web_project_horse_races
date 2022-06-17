using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.EntityFramework;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_db.Repository;
using Web_project_horse_races_db.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Web_project_horse_races_web.Controllers
{
    public class HorseController : Controller
    {
        ApplicationContext db;
        public HorseController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<Horse> horses = db.Horses.ToList();
            return View(horses);
        }
        [HttpPost]
        public IActionResult Create(Horse horse)
        {
            db.Horses.Add(horse);
            db.SaveChanges();
            return LocalRedirect("~/Horse/Index");
        }

        [HttpPost]
        public IActionResult Update(Horse horse)
        {
            db.Horses.Update(horse);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Horse horse)
        {
            db.Horses.Remove(horse);
            db.SaveChanges();
            return LocalRedirect("~/Horse/Index");
        }
    }
}
