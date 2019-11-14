using RentalService.DAL.Entities;
using System.Threading.Tasks;

namespace RentalService.DAL.Contracts
{
    public interface ICityRepository : IBaseRepository<City>
    {
        bool CityExists(int id);
    }
}
