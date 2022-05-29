using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_db.Repository;
using System.Security.Claims;

namespace Web_project_horse_races_web.Controllers
{
    public class UserController : Controller
    {
        public BaseUserRepository baseUserRepository;

        public UserController()
        {
            baseUserRepository = new UserRepository();
        }

        [HttpGet("UserList")]
        public IActionResult Index()
        {
            List<BaseUser> users = baseUserRepository.GetAll();
            return View(users);

        } 

        [Route("SingleUser/{id?}")]
        public IActionResult Index(int id, Role role)
        {
            if (role == Role.USER)
            {
                User user = new UserRepository().GetOneById(id);
                return View("SingleUser", user);
            }
            if (role == Role.BOOKMAKER)
            {
                Bookmaker bookmaker = new BookmakerRepository().GetOneById(id);
                return View("SingleBookmaker", bookmaker);
            }
            return StatusCode(404);
        }

        [HttpPost]
        public IActionResult Create(string name, string email, string password, int roleId)
        {
            UserRole role = new UserRolesRepository().GetOneById(roleId);

            if (role.RoleName == Role.USER)
            {
                UserRepository userRepository = new UserRepository();
                User user = new User(name, email, password);
                user.RoleId = role.Id;
                userRepository.Save(user);
                user.Role = role;
            }
            if (role.RoleName == Role.BOOKMAKER)
            {
                BookmakerRepository bookmakerRepository = new BookmakerRepository();
                Bookmaker bookmaker = new Bookmaker(name, email, password);
                bookmaker.RoleId = role.Id;
                bookmakerRepository.Save(bookmaker);
                bookmaker.Role = role;
            }
            return LocalRedirect("~/UserList");
        }

        //[HttpGet]
        //public IActionResult BanUser(int id)
        //{   
        //    userRepository.ChangeUserBanState(id);
        //    return LocalRedirect("~/UserList");
        //}

        //[HttpGet]
        //public IActionResult DeleteUser(int id)
        //{
        //    userRepository.Delete(id);
        //    return LocalRedirect("~/UserList");
        //}

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


        public IActionResult MakeBet(decimal betSum, int bookmakerBetId)
        {
            Claim idClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id");
            int userId = int.Parse(idClaim.Value);
            User user = new UserRepository().GetOneById(userId);

            BookmakerBetRepository bookmakerBetRepository = new BookmakerBetRepository();
            BookmakerBet bet = bookmakerBetRepository.GetOneById(bookmakerBetId);
            UserBet userBet = new UserBet() { UserId = user.Id, BookmakerBetId = bookmakerBetId, BetSum = betSum, PossibleWinSum = decimal.Multiply(betSum, (decimal)bet.Coefficient) };
            new UserRepository().AddUserBet(userBet);
            return LocalRedirect("~/Race/Index");

        }


    }
}
