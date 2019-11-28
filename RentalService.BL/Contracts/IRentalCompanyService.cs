using RentalService.BL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalService.BL.Contracts
{
    public interface IRentalCompanyService
    {
        Task<IEnumerable<RentalCompanyDTO>> GetAllRentalCompaniesAsync();
        Task<RentalCompanyDTO> GetRentalCompanyAsync(int? id);
        Task<IEnumerable<RentalCompanyDTO>> FindRentalCompaniesAsync(string searchString, string cityName);
        Task AddRentalCompanyAsync(RentalCompanyDTO rentalCompany);
        Task UpdateRentalCompanyAsync(RentalCompanyDTO rentalCompany);
        Task DeleteRentalCompanyAsync(int id);
        bool RentalCompanyExists(int id);
    }
}
