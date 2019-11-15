using RentalService.DAL.Entities;

namespace RentalService.DAL.Contracts
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        bool CountryExists(int id);
    }
}
