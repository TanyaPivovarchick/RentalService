using RentalService.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalService.DAL.Contracts
{
    public interface ICityRepository : IBaseRepository<City>
    {
        Task<IEnumerable<City>> FindAsync(string searchString, string countryName);
        bool CityExists(int id);
    }
}
