using RentalService.BL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalService.BL.Contracts
{
    public interface ICityService
    {
        Task<IEnumerable<CityDTO>> GetAllCitiesAsync();
        Task<CityDTO> GetCityAsync(int? id);
        Task<IEnumerable<CityDTO>> FindCitiesAsync(string searchString, string countryName);
        Task AddCityAsync(CityDTO city);
        Task UpdateCityAsync(CityDTO city);
        Task DeleteCityAsync(int id);
        bool CityExists(int id);
    }
}
