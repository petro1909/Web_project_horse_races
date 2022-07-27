using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_web.ViewModel.AccountModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Web_project_horse_races_web.Services;
using Microsoft.AspNetCore.Authorization;
using Web_project_horse_races_web.Infrastructure.Filters;
using Web_project_horse_races_db.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Web_project_horse_races_web.Controllers
{
    public class AccountController : Controller

    {
        readonly ApplicationContext db;
        public AccountController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(LoginUserViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View("Login", new LoginViewModel() { LoginUserViewModel = model});
            }

            User user = db.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            if (user == null)
            {
                return View("Login", model);
            }
            await AuthenticateUser(user);
            return LocalRedirect("~/Home/Index");
        }


        [HttpPost]
        public async Task<IActionResult> BookmakerLogin(LoginBookmakerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Login");
            }

            Bookmaker bookmaker = db.Bookmakers.FirstOrDefault(b => b.Name == model.Name && b.Password == model.Password);
            if (bookmaker == null)
            {
                return View("Login");
            }
            await AuthenticateBookmaker(bookmaker);
            return LocalRedirect("~/Home/Index");
        }


        private async Task AuthenticateUser(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.RoleName.ToString()),
                new Claim("id", $"{user.Id}"),
                new Claim("banState", $"{user.BanState}"),
                new Claim("type", "user")
            };
            ClaimsIdentity id = new(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        private async Task AuthenticateBookmaker(Bookmaker bookmaker)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, bookmaker.Name),
                new Claim("type", "bookmaker")
            };
            ClaimsIdentity id = new(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("~/Home/Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserViewModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }

            UserRole role = db.UserRoles.FirstOrDefault(ur => ur.RoleName == Role.USER);
            User user = new User(registerModel.Name, registerModel.Email, registerModel.Password) { RoleId = role.Id };
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
            } 
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            } 
            user.Role = role;
            await AuthenticateUser(user);
            
            return View(registerModel);
        }


        [HttpPost]
        public async Task<IActionResult> RegisterBookmaker(RegisterBookmakerViewModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }

            Bookmaker bookmaker = new Bookmaker(registerModel.Name, registerModel.Password);
            try
            {
                db.Bookmakers.Add(bookmaker);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            await AuthenticateBookmaker(bookmaker);

            return View(registerModel);
        }

        [Authorize]
        [Route("Account/ShowUserProfile/{id?}")]
        public IActionResult ShowUserProfile(string strIdentifier)
        {
            //User user = db.Users.Include(u => u.Role).Include(u => u.UserBets).ThenInclude(ub => ub.UserBetType).
            //    Include(u => u.UserBets).ThenInclude(ub => ub.BookmakerRaceBet).ThenInclude(brb => brb.Race).
            //    Include(u => u.UserBets).ThenInclude(ub => ub.BookmakerRaceBet).ThenInclude(brb => brb.Bookmaker).
            //    Include(u => u.UserBets).ThenInclude(ub => ub.BookmakerBets).ThenInclude(bb => bb.RaceParticipant).ThenInclude(rp => rp.Horse).
            //    FirstOrDefault(u => u.Email == strIdentifier);
            //if (user != null)
            //{
            //    return View("~/Views/User/SingleUser.cshtml", user);
            //}            
            return StatusCode(404);
        }



        [Authorize]
        [Route("Account/ShowBookmakerProfile/{id?}")]
        public IActionResult ShowBookmakerProfile(string strIdentifier)
        {
            //Bookmaker bookmaker = db.Bookmakers.Include(b => b.BookmakerRaceBets).ThenInclude(bb => bb.Race).
            //    Include(b => b.BookmakerRaceBets).ThenInclude(brb => brb.UserBets).ThenInclude(ub => ub.BookmakerBets).ThenInclude(bb => bb.RaceParticipant).ThenInclude(rp => rp.Horse).
            //    FirstOrDefault(u => u.Name == strIdentifier);
            //if (bookmaker != null)
            //{
            //    return View("~/Views/User/SingleUser.cshtml", bookmaker);
            //}
            return StatusCode(404);
        }


        //public IActionResult Update(int id, string name, string email, string password)
        //{
        //    User baseUser = userService.GetOneBaseUserById(id);
        //    baseUser.Name = name;
        //    baseUser.Email = email;
        //    baseUser.Password = password;
        //    userService.UpdateUser(baseUser);
        //    return LocalRedirect($"~/Account/ShowProfile/{baseUser.Id}");
        //}

        public IActionResult RenderPartialUserLogin()
        {
            return PartialView("UserLogin");
        }
    }
}
