using RentalService.DAL.Entities;

namespace RentalService.DAL.Contracts
{
    public interface ICityRepository : IBaseRepository<City>
    {
        bool CityExists(int id);
    }
}
