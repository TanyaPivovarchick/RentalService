using Microsoft.EntityFrameworkCore;
using RentalService.DAL.Contracts;
using RentalService.DAL.Entities;
using System.Threading.Tasks;

namespace RentalService.DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RentalServiceContext db;

        public RoleRepository(RentalServiceContext context)
        {
            db = context;
        }

        public Task<Role> GetAsync(string name)
        {
            return db.Roles.FirstOrDefaultAsync(r => r.Name == name);
        }
    }
}
