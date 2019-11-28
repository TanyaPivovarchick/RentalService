using Microsoft.EntityFrameworkCore;
using RentalService.DAL.Contracts;
using RentalService.DAL.Entities;
using System.Threading.Tasks;

namespace RentalService.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RentalServiceContext db;

        public UserRepository(RentalServiceContext context)
        {
            db = context;
        }

        public Task<User> GetUserAsync(string email)
        {
            return db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public Task<User> GetUserAsync(string email, string password)
        {
            return db.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public Task<bool> UserExistsAsync(string email)
        {
            return db.Users.AnyAsync(u => u.Email == email);
        }

        public void Add(User user)
        {
            db.Users.Add(user);
        }
    }
}
