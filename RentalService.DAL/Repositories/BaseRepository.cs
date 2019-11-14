using Microsoft.EntityFrameworkCore;
using RentalService.DAL.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalService.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly RentalServiceContext db;

        public BaseRepository(RentalServiceContext context)
        {
            db = context;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await db.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetAsync(int? id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        public virtual void Add(T entity)
        {
             db.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            db.Set<T>().Update(entity);
        }

        public virtual void Delete(T entity)
        {
            db.Set<T>().Remove(entity);
        }
    }
}
