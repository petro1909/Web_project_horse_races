using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_project_horse_races_db.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetOneById(int id);
        void Save(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);
        void DeleteAll();
    }
}
