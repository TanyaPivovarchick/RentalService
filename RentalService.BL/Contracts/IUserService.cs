using RentalService.BL.DTO;
using System.Threading.Tasks;

namespace RentalService.BL.Contracts
{
    public interface IUserService
    {
        Task<UserDTO> GetUserAsync(string email);
        Task<UserDTO> GetUserAsync(string email, string password);
        Task<UserDTO> RegisterUserAsync(string email, string password);
    }
}
