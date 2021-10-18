using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class GiftedPersonRepository : IRepository<GiftedPerson>
    {
        GivemePresentDBEntities context = new GivemePresentDBEntities();

        public void Add(GiftedPerson item)
        {
            context.GiftedPerson.Add(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(GiftedPerson item)
        {
            throw new NotImplementedException();
        }

        public bool Exits(int id)
        {
            throw new NotImplementedException();
        }

        public GiftedPerson Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GiftedPerson> GetAll()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(GiftedPersonRepository item)
        {
            throw new NotImplementedException();
        }

        public void Update(GiftedPerson item)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        ////////////////////////////////////////////////////
        // Implantación de IDisposable

        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
