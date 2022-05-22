using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_db.Repository;

namespace Web_project_horse_races_web.Controllers
{
    public class UserController : Controller
    {
        public UserRepository userRepository;

        public UserController()
        {
            userRepository = new UserRepository();
        }

        [HttpGet("UserList")]
        public IActionResult Index()
        {
            List<User> users = userRepository.GetAll();
            return View(users);

        }

        [Route("SingleUser/{id?}")]
        public IActionResult Index(int id)
        {
            User user = userRepository.GetOneById(id);
            return View("SingleUser", user);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            userRepository.Save(user);
            return LocalRedirect("~/UserList");
        }
        
        [HttpGet]
        public IActionResult BanUser(int id)
        {   
            userRepository.ChangeUserBanState(id);
            return LocalRedirect("~/UserList");
        }

        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            userRepository.Delete(id);
            return LocalRedirect("~/UserList");
        }

        [HttpPost]
        public IActionResult Update(int id, string name, string email, string password)
        {
            User user = userRepository.GetOneById(id);
            user.Name = name;
            user.Email = email;
            user.Password = password;
            userRepository.Update(user);
            return LocalRedirect($"~/SingleUser?id={id}");
        }


    }
}
