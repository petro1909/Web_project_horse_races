using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_db.Repository;
using Web_project_horse_races_web.ViewModel.RaceModel;
using System.Security.Claims;
using Web_project_horse_races_db.EntityFramework;
using Web_project_horse_races_web.Services;
using Microsoft.AspNetCore.Authorization;
using Web_project_horse_races_web.Util;
using Microsoft.EntityFrameworkCore;

namespace Web_project_horse_races_web.Controllers
{
    public class RaceController : Controller
    {
        readonly ApplicationContext db;
        public RaceController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Race> races = db.Races.ToList();
            RacesViewModel racesViewModel = new RacesViewModel(races);
            return View(racesViewModel);
        }

        public IActionResult ShowRaceDetails(int raceId)
        {
            Race race = db.Races.Include(r => r.RaceParticipants).ThenInclude(rp => rp.Horse).
                Include(r => r.RaceParticipants).ThenInclude(rp => rp.BookmakerBets).ThenInclude(bb => bb.BookmakerRaceBet).FirstOrDefault(r => r.Id == raceId);
            //RaceViewModel raceViewModel = new RaceViewModel(race);
            return PartialView("RaceDetails", race);
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult CreateRace() 
        {
            List<Horse> horses = db.Horses.ToList();
            return View(horses);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public IActionResult CreateRace(DateTime datetime, List<RaceParticipant> raceParticipants)
        {
            Race race = new Race(datetime, raceParticipants);
            try
            {
                db.Races.Add(race);
                db.SaveChanges();
            } 
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Json(Url.Action("Index"));
        }

        [HttpGet]
        [Route("/Race/EditRace/{id}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult EditRace(int id)
        {
            Race race = db.Races.Include(r => r.RaceParticipants).ThenInclude(rp => rp.Horse).FirstOrDefault(r => r.Id == id);
            List<Horse> horses = db.Horses.ToList();
            EditRaceViewModel raceModel = new EditRaceViewModel(race);
            return View(raceModel);
        }


        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public IActionResult EditRace(EditRaceViewModel raceModel)
        {
            Race race = raceModel.Race;
            try
            {
                db.Races.Update(race);
                db.SaveChanges();
            } 
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return LocalRedirect($"EditRace/{race.Id}");
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public IActionResult DeleteRace(int raceId)
        {
            try
            {
                Race race = db.Races.Find(raceId);
                db.Races.Remove(race);
                db.SaveChanges();
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } 
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult StartRace(int raceId)
        {
            using (db)
            {
                Race race = db.Races.Find(raceId);
                race.RaceStatus = RaceStatus.RUNNING;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EndRace(int raceId)
        {
            using (db)
            {
                Race race = db.Races.Find(raceId);
                race.RaceStatus = RaceStatus.ENDED;
            }
            return RedirectToAction("Index");
        }


        //[HttpGet]
        //public JsonResult GetBetTypes()
        //{
        //    return Json(raceService.GetRaceBetTypes());
        //}


        //[Route("/Race/ShowUserBetParialView/{bookmakerBetId}")]
        //public IActionResult ShowUserBetParialView(int id)
        //{
        //    BookmakerBet bet = userService.GetBookmakerBetById(id);
        //    return PartialView("UserBet", bet);
        //}
    }
}
