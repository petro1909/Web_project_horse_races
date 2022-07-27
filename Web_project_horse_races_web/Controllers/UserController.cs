using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web_project_horse_races_web.ViewModel.AccountModel;
using Web_project_horse_races_web.Infrastructure.Filters;
using Web_project_horse_races_web.Services;
using Web_project_horse_races_web.Util;
using Web_project_horse_races_db.EntityFramework;
using Microsoft.EntityFrameworkCore;
namespace Web_project_horse_races_web.Controllers
{
    //[Authorize(Roles = "ADMIN")]
    public class UserController : Controller
    {
        readonly ApplicationContext db;
                
        public UserController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet("UserList")]
        public IActionResult Index()
        {
            List<User> users = db.Users.Include(u => u.Role).ToList();

            //ViewBag.UserRoles = new SelectList(RegisterViewModel.GetUserRoles(), "Id", "RoleName");
            return View(users);

        }
        [HttpGet]
        [Route("SingleUser/{id?}")]
        public IActionResult Index(int id)
        {
            //User user = db.Users.Include(u => u.Role).Include(u => u.UserBets).ThenInclude(ub => ub.UserBetType).
            //    Include(u => u.UserBets).ThenInclude(ub => ub.BookmakerRaceBet).ThenInclude(brb => brb.Race).
            //    Include(u => u.UserBets).ThenInclude(ub => ub.BookmakerRaceBet).ThenInclude(brb => brb.Bookmaker).
            //    Include(u => u.UserBets).ThenInclude(ub => ub.BookmakerBets).ThenInclude(bb => bb.RaceParticipant).ThenInclude(rp => rp.Horse).
            //    FirstOrDefault(u => u.Id == id);
            //if (user != null)
            //{
            //    return View("SingleUser", user);
            //}
            return StatusCode(404);
        }

        [HttpPost]
        public IActionResult Create(string name, string email, string password, int roleId)
        {
            //UserRole role = new UserRolesRepository().GetOneById(roleId);

            //if (role.RoleName == Role.USER || role.RoleName == Role.ADMIN)
            //{
            //    User user = new User(name, email, password) { RoleId = role.Id};
            //    userService.CreateUser(user);
            //}
            //if (role.RoleName == Role.BOOKMAKER)
            //{
            //    Bookmaker bookmaker = new Bookmaker(name, email, password) { RoleId = role.Id};
            //    userService.CreateBookmaker(bookmaker);
            //}
            return LocalRedirect("~/UserList");
        }

        [HttpGet]
        public IActionResult BanUser(int id)
        {
            using(db) {
                User user = db.Users.Find(id);
                user.BanState = !user.BanState;
            }
            return LocalRedirect("~/UserList");
        }

        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return LocalRedirect("~/UserList");
        }

        public IActionResult DeleteAllUsers()
        {
            db.Database.ExecuteSqlRaw("DELETE Users");
            db.SaveChanges();
            return LocalRedirect("~/UserList");
        }

        //[HttpPost]
        //public IActionResult Update(int id, string name, string email, string password)
        //{
        //    User user = userRepository.GetOneById(id);
        //    user.Name = name;
        //    user.Email = email;
        //    user.Password = password;
        //    userRepository.Update(user);
        //    return LocalRedirect($"~/SingleUser?id={id}");
        //}

       
        public IActionResult CreateRandomUsers(int count, int startIndex)
        {
            DateTime now = DateTime.Now;
            List<User> users = EntityGenerator.CreateRandomUsers(count, startIndex);
            try {
                db.Users.AddRange(users);    
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            TimeSpan now1 = DateTime.Now - now;
            ViewBag.Time = now1;
            
            
            Console.WriteLine(now1);
            Console.WriteLine(now1);
            return LocalRedirect("~/UserList");
        }



        //[Authorize]
        //[UnbannedUser]
        public IActionResult MakeBet(decimal betSum, int bookmakerBetId)
        {
            Claim idClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id");
            int userId = int.Parse(idClaim.Value);

            BookmakerBet bet = db.BookmakerBets.Find(bookmakerBetId);
            List<BookmakerBet> bets = new List<BookmakerBet>();
            bets.Add(bet);
            
            decimal possibleWin = decimal.Multiply(betSum, (decimal)bet.Coefficient);
            
            UserBet userBet = new UserBet() { UserId = userId, BookmakerBets = bets, BetSum = betSum, PossibleWinSum = possibleWin, BookmakerRaceBetId = bet.BookmakerRaceBetId};
            db.UserBets.Add(userBet);
            db.SaveChanges();
            return LocalRedirect("~/Race/Index");
        }

        public string GetUserRole()
        {
            return User.FindFirst(u => u.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
        }
    }
}
