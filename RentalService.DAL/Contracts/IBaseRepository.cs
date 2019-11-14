using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalService.DAL.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int? id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
