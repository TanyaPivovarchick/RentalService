using RentalService.DAL.Entities;
using System.Threading.Tasks;

namespace RentalService.DAL.Contracts
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        bool CountryExists(int id);
    }
}
