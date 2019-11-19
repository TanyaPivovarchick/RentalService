using Mapster;
using RentalService.BL.Contracts;
using RentalService.BL.DTO;
using RentalService.DAL.Contracts;
using System;
using System.Threading.Tasks;

namespace RentalService.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork db;

        public UserService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        public async Task<UserDTO> GetUserAsync(string email, string password)
        {
            var user = await db.UserRepository.GetUserAsync(email, password);

            if (user == null)
            {
                throw new Exception("Invalid email or(and) password");
            }

            return user.Adapt<UserDTO>();
        }

        public async Task<UserDTO> RegisterUserAsync(string email, string password)
        {
            if (await db.UserRepository.UserExistsAsync(email))
            {
                throw new Exception("User with such email already exists");
            }

            UserDTO user = new UserDTO(email, password);

            var role = await db.RoleRepository.GetAsync("User");
            if (role != null)
            {
                user.Role = role.Adapt<RoleDTO>();
            }

            await db.Save();

            return user;
        }
    }
}
