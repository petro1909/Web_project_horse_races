using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;
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
        readonly UserService userService;
        readonly RaceService raceService;
        readonly BetService betService;
        public RaceController(ApplicationContext db, UserService userService, RaceService raceService, BetService betService)
        {
            this.db = db;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Race> races = db.Races.ToList();
            ViewBag.User = userService.GetUserType(User);
            //RacesViewModel racesViewModel = new RacesViewModel(races);
            return View("RacesList", races);
        }

        public IActionResult ShowRaceDetails(int raceId)
        {
            Race race = db.Races.Include(r => r.RaceParticipants).ThenInclude(rp => rp.Horse).
                Include(r => r.RaceParticipants).ThenInclude(rp => rp.BetTypes).ThenInclude(bt => bt.BetType).
                Include(r => r.RaceParticipants).ThenInclude(rp => rp.BetTypes).ThenInclude(bb => bb.BookmakerBets).FirstOrDefault(r => r.Id == raceId);
            RaceViewModel raceVM = new RaceViewModel(race);

            return PartialView("SingleRaceUser", raceVM);
        }


        public IActionResult ShowBetRaceParticipants(int raceId, int betTypeId)
        {
            Race race = db.Races.Include(r => r.RaceParticipants).ThenInclude(rp => rp.Horse).
                Include(r => r.RaceParticipants).ThenInclude(rp => rp.BetTypes).ThenInclude(bt => bt.BetType).
                Include(r => r.RaceParticipants).ThenInclude(rp => rp.BetTypes).ThenInclude(bb => bb.BookmakerBets).ThenInclude(bb => bb.BookmakerRaceBet).ThenInclude(brb => brb.Bookmaker).FirstOrDefault(r => r.Id == raceId);
            RaceViewModel raceVM = new RaceViewModel(race);

            List<RaceParticipantBet> raceParticipantBets = db.RaceParticipantBet.Where(rpb => rpb.RaceParticipant.RaceId == raceId && rpb.BetTypeId == betTypeId).OrderBy(rpb => rpb.RaceParticipant.Number).ToList();
            string userType = userService.GetUserType(User);
            ViewBag.UserType = userType;
            return PartialView("BetRaceParticipants", raceParticipantBets);
        }



        [Authorize(Roles = "ADMIN")]
        public JsonResult AddRandomHorsesForCreatingRace(int horseNumber)
        {
            Random r = new Random();
            
            List<Horse> horses = db.Horses.ToList();
            List<Horse> randomHorses = new List<Horse>(horseNumber);
            for (int i = 0; i < horseNumber; )
            {
                int index = r.Next(0, horseNumber);
                Horse horse = horses[index];
                if(!randomHorses.Contains(horse))
                {
                    randomHorses.Add(horse);
                    i++;
                } 
            }
            return Json(randomHorses);
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
            List<BetType> betTypes = db.BetTypes.ToList();

            foreach (RaceParticipant participant in raceParticipants)
            {
                participant.BetTypes = new List<RaceParticipantBet>();
                foreach(BetType betType in betTypes)
                {
                    participant.BetTypes.Add(new RaceParticipantBet() { RaceParticipant = participant, BetTypeId = betType.Id });
                }
            }
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
        [Authorize(Roles = "ADMIN")]
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
        [Authorize(Roles = "ADMIN")]
        public IActionResult EndRace(int raceId)
        {
            Race race;
            using (db)
            {
                race = db.Races.Find(raceId);
                race.RaceStatus = RaceStatus.ENDED;
            }
            raceService.EndRace(race);
            betService.CalculateUserBetsOfEndedRace(race);
            return RedirectToAction("Index");
        }


        //[HttpGet]
        //public JsonResult GetBetTypes()
        //{
        //    return Json(raceService.GetRaceBetTypes());
        //}


        //[Route("/Race/ShowUserBetParialView/{id}")]
        public IActionResult ShowUserBetParialView(int id)
        {
            BookmakerBet bet = db.BookmakerBets.Include(bb => bb.RaceParticipantBet).ThenInclude(rpb => rpb.RaceParticipant).ThenInclude(rp => rp.Horse).
                                                Include(bb => bb.RaceParticipantBet).ThenInclude(rpb => rpb.RaceParticipant).ThenInclude(rp => rp.Race).
                                                Include(bb => bb.RaceParticipantBet).ThenInclude(rpb => rpb.BetType).
                                                Include(bb => bb.BookmakerRaceBet).SingleOrDefault(bb => bb.Id == id);
            return PartialView("UserBet", bet);
        }
    }
}
