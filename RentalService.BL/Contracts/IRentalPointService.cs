using RentalService.BL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalService.BL.Contracts
{
    public interface IRentalPointService
    {
        Task<IEnumerable<RentalPointDTO>> GetAllRentalPointsAsync();
        Task<RentalPointDTO> GetRentalPointAsync(int? id);
        Task AddRentalPointAsync(RentalPointDTO rentalPoint);
        Task UpdateRentalPointAsync(RentalPointDTO rentalPoint);
        Task DeleteRentalPointAsync(int id);
        bool RentalPointExists(int id);
    }
}
