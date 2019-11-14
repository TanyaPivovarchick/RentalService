using RentalService.BL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalService.BL.Contracts
{
    public interface ICityService
    {
        Task<IEnumerable<CityDTO>> GetAllCitiesAsync();
        Task<CityDTO> GetCityAsync(int? id);
        Task AddCity(CityDTO city);
        Task UpdateCity(CityDTO city);
        Task DeleteCity(int id);
        bool CityExists(int id);
    }
}
