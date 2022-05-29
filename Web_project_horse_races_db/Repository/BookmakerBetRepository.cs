using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_db.EntityFramework;

namespace Web_project_horse_races_db.Repository
{
    public class BookmakerBetRepository : IRepository<BookmakerBet>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(BookmakerBet entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public List<BookmakerBet> GetAll()
        {
            throw new NotImplementedException();
        }

        public BookmakerBet GetOneById(int id)
        {
            ApplicationContext db = new ApplicationContext();
            BookmakerBet bookmakerBet = db.BookmakerBets.Find(id);
            bookmakerBet.Bookmaker = db.Bookmakers.Find(bookmakerBet.BookmakerId);
            bookmakerBet.UserBets = db.UserBets.Where(ub => ub.BookmakerBetId == bookmakerBet.Id).ToList();
            bookmakerBet.RaceParticipantBet = new RaceBetRepository().GetOneById(bookmakerBet.RaceParticipantBetId);
            return bookmakerBet;
        }

        public List<BookmakerBet> GetRangeByBookmakerId(int id)
        {
            using ApplicationContext db = new ApplicationContext();
            List<BookmakerBet> bookmakerBets = db.BookmakerBets.Where(bb => bb.BookmakerId == id).ToList();
            foreach (BookmakerBet bookmakerBet in bookmakerBets)
            {
                bookmakerBet.UserBets = db.UserBets.Where(ub => ub.BookmakerBetId == bookmakerBet.Id).ToList();
                bookmakerBet.RaceParticipantBet = new RaceBetRepository().GetOneById(bookmakerBet.RaceParticipantBetId);
            }
            return bookmakerBets;
        }

        public void Save(BookmakerBet entity)
        {
            throw new NotImplementedException();
        }

        public void Update(BookmakerBet entity)
        {
            throw new NotImplementedException();
        }
    }
}
