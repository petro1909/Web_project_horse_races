using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_db.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Web_project_horse_races_db.Repository
{
    public class BookmakerRepository : BaseRepository, IRepository<Bookmaker>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Bookmaker entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public List<Bookmaker> GetAll()
        {
            using ApplicationContext db = new ApplicationContext();
            return db.Bookmakers.Include(u => u.Role).Include(u => u.BookmakerBets).ToList();
        }

        public Bookmaker GetOneById(int id)
        {
            using ApplicationContext db = new ApplicationContext();
            Bookmaker bookmaker = db.Bookmakers.Find(id);
            bookmaker.Role = db.Roles.FirstOrDefault(ur => ur.Id == bookmaker.RoleId);
            bookmaker.BookmakerBets = new BookmakerBetRepository().GetRangeByBookmakerId(id);
            return bookmaker;
        }

        public void MakeBet(BookmakerBet bet)
        {
            using ApplicationContext db = new ApplicationContext();
            db.BookmakerBets.Add(bet); 
            db.SaveChanges();
        }

        public void Save(Bookmaker bookmaker)
        {
            using ApplicationContext db = new ApplicationContext();
            db.Bookmakers.Add(bookmaker);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine("User with the same email already exist");
            }
        }

        public void Update(Bookmaker entity)
        {
            throw new NotImplementedException();
        }
    }
}
