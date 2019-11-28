using RentalService.BL.DTO;
using RentalService.BL.DTO.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalService.BL.Contracts
{
    public interface IRentalPointCarService
    {
        Task<RentalPointCarDTO> GetRentalPointCarAsync(int? id);
        Task<IEnumerable<RentalPointCarDTO>> SearchAsync(RentalPointCarFilterDTO filter);
        Task UpdateRentalPointCarAsync(RentalPointCarDTO rentalPointCar);
        Task DeleteRentalPointCarAsync(int id);
        bool RentalPointCarExists(int id);
    }
}
