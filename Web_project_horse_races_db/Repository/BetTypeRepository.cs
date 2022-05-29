using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_db.EntityFramework;

namespace Web_project_horse_races_db.Repository
{
    public class BetTypeRepository : IRepository<RaceBetType>
    {
        
        public List<RaceBetType> GetAll()
        {
            ApplicationContext db = new ApplicationContext();
            return db.RaceBetTypes.ToList();
        }

        public RaceBetType GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(RaceBetType entity)
        {
            throw new NotImplementedException();
        }

        public void Update(RaceBetType entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(RaceBetType entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }
    }
}
