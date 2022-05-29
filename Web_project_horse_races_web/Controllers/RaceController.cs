using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_db.Repository;
using Web_project_horse_races_web.ViewModel;
using System.Security.Claims;
using Web_project_horse_races_db.EntityFramework;

namespace Web_project_horse_races_web.Controllers
{
    public class RaceController : Controller
    {
        RaceRepository raceRepository;
        HorseRepository horseRepository;
        RaceParticipantRepository raceParticipantRepository;
        RaceBetRepository raceBetRepository;
        UserRepository userRepository;
        BetTypeRepository betTypeRepository;
        public RaceController()
        {
            raceRepository = new RaceRepository();
            horseRepository = new HorseRepository();
            raceParticipantRepository = new RaceParticipantRepository();
            raceBetRepository = new RaceBetRepository();
            userRepository = new UserRepository();
            betTypeRepository = new BetTypeRepository();
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Race> races = raceRepository.GetAll();
            RacesViewModel racesViewModel = new RacesViewModel(races);
            return View(racesViewModel);
        }

        [Route("/Race/ShowRaceDetails/{id}")]
        public IActionResult ShowRaceDetails(int id)
        {
            Race race = raceRepository.GetOneById(id);
            RaceViewModel raceViewModel = new RaceViewModel(race);
            return PartialView("RaceDetails", raceViewModel);
        }


        [HttpPost]
        public IActionResult AddParticipant(byte number, int id, int raceId)
        {
            Horse horse = horseRepository.GetOneById(id);
            RaceParticipant raceParticipant = new RaceParticipant(number) { RaceId = raceId, HorseId = id};
            raceRepository.AddRaceParticipant(raceParticipant);
            return LocalRedirect("~/Race/Index");
        }

        [HttpGet]
        public IActionResult DeleteParticipant(RaceParticipant raceParticipant)
        {
            raceParticipantRepository.Delete(raceParticipant);
            return LocalRedirect("~/Race/Index");
        }
        [HttpPost]
        public IActionResult RegisterUserBet(string betSum, int raceBetId)
        {
            RaceParticipantBet raceBet = raceBetRepository.GetOneById(raceBetId);
            int userId = int.Parse(HttpContext.Request.Cookies["Id"]);

            decimal userBetSum = decimal.Parse(betSum);

            return LocalRedirect("~/Race/Index");
        }

        [HttpGet]
        public IActionResult AddRace()
        {
            List<Horse> horses = horseRepository.GetAll();
            ViewBag.Horses = horses;
            return View(horses);
        }

        [HttpPost]
        public IActionResult AddRace(DateTime datetime, List<RaceParticipant> raceParticipants)
        {

            Race race = new Race(datetime, raceParticipants);
            raceRepository.Save(race);
            return Json(Url.Action("Index"));
        }

        [HttpGet]
        public JsonResult GetBetTypes()
        {
            return Json(betTypeRepository.GetAll());
        }

        public IActionResult MakeBookmakerBet(int RaceParticipantBetId,  double betCoefficient)
        {
            Claim idClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id");
            int userId = int.Parse(idClaim.Value);
            BookmakerRepository bookmakerRepository = new BookmakerRepository();
            
            Bookmaker bookmaker = bookmakerRepository.GetOneById(userId);


            BookmakerBet bookmakerBet = new BookmakerBet() { BookmakerId = bookmaker.Id, Coefficient = betCoefficient, RaceParticipantBetId = RaceParticipantBetId };


            bookmakerRepository.MakeBet(bookmakerBet);
            return LocalRedirect("~/Race/Index");
        }

    }
}
