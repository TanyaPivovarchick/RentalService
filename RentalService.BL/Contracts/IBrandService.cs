using RentalService.BL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalService.BL.Contracts
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDTO>> GetAllBrandsAsync();
        Task<BrandDTO> GetBrandAsync(int? id);
        Task AddBrandAsync(BrandDTO brand);
        Task UpdateBrandAsync(BrandDTO brand);
        Task DeleteBrandAsync(int id);
        bool BrandExists(int id);
    }
}
