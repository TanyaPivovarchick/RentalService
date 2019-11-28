using RentalService.DAL.Entities;
using System.Threading.Tasks;

namespace RentalService.DAL.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string email);
        Task<User> GetUserAsync(string email, string password);
        Task<bool> UserExistsAsync(string email);
        void Add(User user);
    }
}
