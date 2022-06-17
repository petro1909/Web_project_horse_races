using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.EntityFramework;
using Web_project_horse_races_db.Model;
using Microsoft.EntityFrameworkCore;

namespace Web_project_horse_races_web.Services
{
    public class UserService
    {
        public List<User> GetAllUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Users.Include(u => u.Role).ToList();
            }
        }

        public User GetBaseUserById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User baseUser = db.Users.Include(u => u.Role).FirstOrDefault(bu => bu.Id == id);
                return baseUser;
            }
        }


        public User GetOneByLoginAndPassword(string login, string password)
        {
            using (ApplicationContext db = new ApplicationContext()) 
            {
                User user = db.Users.Include(bu => bu.Role).FirstOrDefault(u => u.Email == login && u.Password == password);
                return user;
            }
        }


        public User GetOneBaseUserById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Users.Find(id);
            }
        }

        public User GetOneUserById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.
                //Include(u => u.UserBets).ThenInclude(ub => ub.BookmakerBet).ThenInclude(bb => bb.Bookmaker).
                //Include(u => u.UserBets).ThenInclude(ub => ub.BookmakerBet).ThenInclude(bb => bb.RaceParticipantBet).ThenInclude(rpb => rpb.RaceBetType).
                //Include(u => u.UserBets).ThenInclude(ub => ub.BookmakerBet).ThenInclude(bb => bb.RaceParticipantBet).ThenInclude(rpb => rpb.RaceParticipant).ThenInclude(rp => rp.Horse).
                //Include(u => u.UserBets).ThenInclude(ub => ub.BookmakerBet).ThenInclude(bb => bb.RaceParticipantBet).ThenInclude(rpb => rpb.RaceParticipant).ThenInclude(rp => rp.Race).
                FirstOrDefault(u => u.Id == id);
                return user;
            }
        }

        public Bookmaker GetOneBookmakerById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Bookmaker user = db.Bookmakers.Find(id);
                //Include(b => b.BookmakerBets).ThenInclude(bb => bb.UserBets).ThenInclude(ub => ub.User).
                //Include(b => b.BookmakerBets).ThenInclude(bb => bb.RaceParticipantBet).ThenInclude(rpb => rpb.RaceBetType).
                //Include(b => b.BookmakerBets).ThenInclude(bb => bb.RaceParticipantBet).ThenInclude(rpb => rpb.RaceParticipant).ThenInclude(rp => rp.Horse).
                //Include(b => b.BookmakerBets).ThenInclude(bb => bb.RaceParticipantBet).ThenInclude(rpb => rpb.RaceParticipant).ThenInclude(rp => rp.Race).
                //FirstOrDefault(u => u.Id == id);
                return user;
            }
        }



        public void CreateUser(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                    db.Users.Add(user);
                    db.SaveChanges(); 
            }
        }

        public void CreateUsers(List<User> users)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.AddRange(users);
                db.SaveChanges();
            }
        }


        public void CreateBookmaker(Bookmaker bookmaker)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Bookmakers.Add(bookmaker);
                db.SaveChanges();
            }
        }

        public void ChangeUserBanState(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = GetBaseUserById(id);
                user.BanState = !user.BanState;
                db.Users.Update(user);
                db.SaveChanges();
            }            
        }



        public void UpdateUser(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Update(user);
                db.SaveChanges();
            }
        }


        public void DeleteSingleUser(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public void DeleteAllBaseUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.ExecuteSqlRaw("DELETE Users; DELETE Bookmakers; DELETE BaseUsers");
            }
        }








        public void MakeUserBet(UserBet bet)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.UserBets.Add(bet);
                db.SaveChanges();
            }
        }

        public void UpdateUserBet(UserBet bet)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.UserBets.Update(bet);
                db.SaveChanges();
            }
        }


        public void MakeBookmakerBet(BookmakerBet bet)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.BookmakerBets.Add(bet);
                db.SaveChanges();
            }
        }

        public void UpdateBookmakerBet(BookmakerBet bet)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.BookmakerBets.Update(bet);
                db.SaveChanges();
            }
        }

        public BookmakerBet GetBookmakerBetById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.BookmakerBets.Find(id);
            }
        }
    }
}
