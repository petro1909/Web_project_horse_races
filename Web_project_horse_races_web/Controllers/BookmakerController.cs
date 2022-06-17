using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_web.Services;
using Web_project_horse_races_db.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Web_project_horse_races_web.Controllers
{
    public class BookmakerController : Controller
    {
        readonly ApplicationContext db;
        public BookmakerController(ApplicationContext db)
        {
            this.db = db;
        }

        public IActionResult MakeBookmakerBet(int raceParticipantBetId, double betCoefficient)
        {
            Claim idClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id");
            int userId = int.Parse(idClaim.Value);


            //RaceParticipantBet raceParticipantBet = raceService.GetOneRPBById(raceParticipantBetId);
            //foreach(BookmakerBet bbet in raceParticipantBet.BookmakerBets)
            //{
            //    if(bbet.BookmakerId == userId)
            //    {
            //        bbet.Coefficient = betCoefficient;
            //        userService.UpdateBookmakerBet(bbet);
            //        return LocalRedirect("~/Race/Index");
            //    }
            //}
            //BookmakerBet bookmakerBet = new BookmakerBet() { BookmakerId = userId, Coefficient = betCoefficient, RaceParticipantBetId = raceParticipantBetId };
            //userService.MakeBookmakerBet(bookmakerBet);
            return LocalRedirect("~/Race/Index");
        }
    }
}
