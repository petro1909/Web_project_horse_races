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
using System.Globalization;

namespace Web_project_horse_races_web.Controllers
{
    public class BookmakerController : Controller
    {
        readonly ApplicationContext db;
        public BookmakerController(ApplicationContext db)
        {
            this.db = db;
        }

        public IActionResult MakeBet(int raceParticipantBetId, string coefficient)
        {
            Claim nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultNameClaimType);
            string name = nameClaim.Value;

            RaceParticipantBet rpbet = db.RaceParticipantBet.Find(raceParticipantBetId);
            int raceId = rpbet.RaceParticipant.RaceId;

            double coeff = double.Parse(coefficient, CultureInfo.InvariantCulture);

            BookmakerRaceBet bookmakerRaceBet = db.BookmakerRaceBets.SingleOrDefault(brb => brb.BookmakerName == name && brb.RaceId == raceId);
            BookmakerBet bet = null;
            if (bookmakerRaceBet == null)
            {
                bookmakerRaceBet = new BookmakerRaceBet() { BookmakerName = name, RaceId = raceId };
                bet = new BookmakerBet() { BookmakerRaceBet = bookmakerRaceBet, Coefficient = coeff, RaceParticipantBetId = raceParticipantBetId };
            } else
            {
                bet = new BookmakerBet() { BookmakerRaceBetId = bookmakerRaceBet.Id, Coefficient = coeff, RaceParticipantBetId = raceParticipantBetId };
            }
            db.BookmakerBets.Add(bet);
            db.SaveChanges();


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
            //BookmakerBet bookmakerBet = new BookmakerBet() { BookmakerId = userId, Coefficient = betCoefficient, RaceParticipantId = raceParticipantId };
            //userService.MakeBookmakerBet(bookmakerBet);
            return LocalRedirect("~/Race/Index");
        }
    }
}
