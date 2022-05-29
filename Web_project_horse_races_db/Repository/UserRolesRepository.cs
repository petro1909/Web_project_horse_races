using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_db.EntityFramework;

namespace Web_project_horse_races_db.Repository
{
    public class UserRolesRepository : IRepository<UserRole>
    {

        public List<UserRole> GetAll()
        {
            using ApplicationContext db = new ApplicationContext();
            return db.Roles.ToList();
        }

        public UserRole GetOneById(int id)
        {
            using ApplicationContext db = new ApplicationContext();
            return db.Roles.Find(id);
        }

        public void Save(UserRole entity)
        {
            throw new NotImplementedException();
        }

        public void Update(UserRole entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserRole entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

    }
}
