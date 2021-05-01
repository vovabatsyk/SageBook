using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repository
{
    public class GenericUnitOfWork : IDisposable
    {
        DbContext _context;

        public GenericUnitOfWork(DbContext context)
        {
            this._context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Dictionary<Type, object> Repositories = new Dictionary<Type, object>();

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (Repositories.Keys.Contains(typeof(T)))
            {
                return Repositories[typeof(T)] as IGenericRepository<T>;
            }

            IGenericRepository<T> repo = new EfGenericRepository<T>(_context);

            Repositories.Add(typeof(T), repo);

            return repo;
        }


        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
