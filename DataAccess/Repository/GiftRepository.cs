using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class GiftRepository : IRepository<Gift>
    {
        GivemePresentDBEntities context = new GivemePresentDBEntities();

        public void Add(Gift item)
        {
            context.Gift.Add(item);
        }

        public void Delete(Gift item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exits(int id)
        {
            throw new NotImplementedException();
        }

        public Gift Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Gift> GetAll()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Gift item)
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
