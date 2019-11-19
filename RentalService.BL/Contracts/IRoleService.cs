using RentalService.BL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalService.BL.Contracts
{
    public interface IRoleService
    {
        Task<BrandDTO> GetRoleAsync(string name);
    }
}
