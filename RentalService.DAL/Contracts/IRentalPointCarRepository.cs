using RentalService.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalService.DAL.Contracts
{
    public interface IRentalPointCarRepository : IBaseRepository<RentalPointCar>
    {
        Task<IEnumerable<RentalPointCar>> SearchAsync(string countryName, string cityName, string companyName);
        bool RentalPointCarExists(int id);
    }
}
