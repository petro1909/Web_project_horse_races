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
    public class BaseUserRepository : IRepository<BaseUser>
    {
        public  List<BaseUser> GetAll()
        {
            ApplicationContext db = new ApplicationContext();
            return db.BaseUsers.Include(bu => bu.Role).ToList();
        }

        public BaseUser GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public BaseUser GetOneByLoginAndPassword(string login, string password)
        {
            using ApplicationContext db = new ApplicationContext();
            BaseUser user = db.BaseUsers.Include(bu => bu.Role).FirstOrDefault(u => u.Email == login && u.Password == password);
            return user;
        }

        public void Save(BaseUser entity)
        {
            throw new NotImplementedException();
        }

        public void Update(BaseUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(BaseUser entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }
    }
}
