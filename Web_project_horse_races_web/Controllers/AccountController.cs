using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Repository;
using Web_project_horse_races_db.Model;

namespace Web_project_horse_races_web.Controllers
{
    public class AccountController : Controller
    {
        UserRepository UserRepository;
        public AccountController()
        {
            UserRepository = new UserRepository();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            User user = UserRepository.GetOneByLoginAndPassword(email, password);
            if (user == null)
            {
                return View("Login");
            }
            HttpContext.Response.Cookies.Append("id", $"{user.Id}");
            HttpContext.Response.Cookies.Append("name", $"{user.Name}");
            return LocalRedirect("~/Home/Index");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.HttpContext.Response.Cookies.Delete("id");
            return LocalRedirect("~/Home/Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string name, string email, string password)
        {
            return View();
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
