using RentalService.BL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalService.BL.Contracts
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDTO>> GetAllCountriesAsync();
        Task<CountryDTO> GetCountryAsync(int? id);
        Task AddCountryAsync(CountryDTO country);
        Task UpdateCountryAsync(CountryDTO country);
        Task DeleteCountryAsync(int id);
        bool CountryExists(int id);
    }
}
