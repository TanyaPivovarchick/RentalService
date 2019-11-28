using RentalService.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalService.DAL.Contracts
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        Task<IEnumerable<Country>> FindAsync(string searchString);
        bool CountryExists(int id);
    }
}
