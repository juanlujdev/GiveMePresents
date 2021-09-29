using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRepository<T>
    {
        void Add(T item);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Update(T item);
        void Delete(T item);
        void Delete(int id);
        bool Exits(int id);
        int SaveChanges();
    }
}
