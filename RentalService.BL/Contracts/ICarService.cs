using RentalService.BL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalService.BL.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<CarDTO>> GetAllCarsAsync();
        Task<CarDTO> GetCarAsync(int? id);
        Task AddCarAsync(CarDTO brand);
        Task UpdateCarAsync(CarDTO brand);
        Task DeleteCarAsync(int id);
        bool CarExists(int id);
    }
}
