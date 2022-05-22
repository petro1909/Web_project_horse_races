using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_db.Repository;

namespace Web_project_horse_races_web.Controllers
{
    public class RaceController : Controller
    {
        RaceRepository raceRepository;
        HorseRepository horseRepository;
        RaceParticipantRepository raceParticipantRepository;
        RaceBetRepository raceBetRepository;
        UserRepository userRepository;
        public RaceController()
        {
            raceRepository = new RaceRepository();
            horseRepository = new HorseRepository();
            raceParticipantRepository = new RaceParticipantRepository();
            raceBetRepository = new RaceBetRepository();
            userRepository = new UserRepository();
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Race> races = raceRepository.GetAll();
            return View(races);
        }
        [Route("/Race/ShowRaceDetails/{id}")]
        public IActionResult ShowRaceDetails(int id)
        {
            Race race1 = raceRepository.GetOneById(id);
            List<Horse> horses = horseRepository.GetAll();
            ViewBag.Horses = horses;
            return PartialView("RaceDetails", race1);
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
            RaceBet raceBet = raceBetRepository.GetOneById(raceBetId);
            int userId = int.Parse(HttpContext.Request.Cookies["Id"]);

            decimal userBetSum = decimal.Parse(betSum);
            decimal possibleWin = userBetSum * (decimal)raceBet.Coefficient;
            UserBet userBet = new UserBet() { BetSum = userBetSum, UserBetProfileId = userId, RaceBetId = raceBetId, coefficient = raceBet.Coefficient, PossibleWinSum = possibleWin };
            userRepository.AddUserBet(userBet);

            raceBet.TotalSum += userBetSum;
            raceBet.UserBetCount += 1;
            raceBetRepository.Update(raceBet);

            return LocalRedirect("~/Race/Index");
        }
    }
}
