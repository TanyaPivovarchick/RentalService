using RentalService.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalService.DAL.Contracts
{
    public interface IRentalCompanyRepository : IBaseRepository<RentalCompany>
    {
        Task<IEnumerable<RentalCompany>> FindAsync(string searchString, string cityName);
        bool RentalCompanyExists(int id);
    }
}
