using RentalService.BL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalService.BL.Contracts
{
    public interface IRentalPointCarService
    {
        Task<IEnumerable<RentalPointCarDTO>> GetAllRentalPointCarsAsync();
        Task<RentalPointCarDTO> GetRentalPointCarAsync(int? id);
        Task AddRentalPointCarAsync(RentalPointCarDTO rentalPointCar);
        Task UpdateRentalPointCarAsync(RentalPointCarDTO rentalPointCar);
        Task DeleteRentalPointCarAsync(int id);
        bool RentalPointCarExists(int id);
    }
}
