using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Repository;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_web.ViewModel.Account;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Web_project_horse_races_web.Controllers
{
    public class AccountController : Controller
    {
        UserRepository UserRepository;
        BaseUserRepository baseRepository;
        public AccountController()
        {
            UserRepository = new UserRepository();
            baseRepository = new BaseUserRepository();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View("Login", model);
            }

            BaseUser user = baseRepository.GetOneByLoginAndPassword(model.Email, model.Password);
            if (user == null)
            {
                return View("Login", model);
            }
            await Authenticate(user);
            return LocalRedirect("~/Home/Index");
        }

        private async Task Authenticate(BaseUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.RoleName.ToString()),
                new Claim("id", $"{user.Id}")
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
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
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }
            BaseUser user;
            UserRole userRole = new UserRolesRepository().GetOneById(registerModel.RoleId);

            if (userRole.RoleName == Role.USER)
            {
                UserRepository userRepository = new UserRepository();
                
                user = new User(registerModel.Name, registerModel.Email, registerModel.Password);
                user.RoleId = userRole.Id;
                userRepository.Save((User)user);
                user.Role = userRole;
                await Authenticate(user);
                return LocalRedirect("~/Home/Index");
            }
            if (userRole.RoleName == Role.BOOKMAKER)
            {
                BookmakerRepository bookmakerRepository = new BookmakerRepository();
                user = new Bookmaker(registerModel.Name, registerModel.Email, registerModel.Password);
                user.RoleId = userRole.Id;
                bookmakerRepository.Save((Bookmaker)user);
                user.Role = userRole;
                await Authenticate(user);
                return LocalRedirect("~/Home/Index");
            }
            return View(registerModel);
        }



        [HttpGet]
        public IActionResult ShowProfile()
        {
            int id = int.Parse(HttpContext.Request.Cookies["id"]);
            User user = UserRepository.GetOneById(id);
            return LocalRedirect($"~/SingleUser?id={id}");

        }


    }
}
