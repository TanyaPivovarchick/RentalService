using RentalService.DAL.Entities;
using System.Threading.Tasks;

namespace RentalService.DAL.Contracts
{
    public interface IRoleRepository
    {
        Task<Role> GetAsync(string name);
    }
}
