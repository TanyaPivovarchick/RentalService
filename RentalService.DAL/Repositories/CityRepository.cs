using Microsoft.EntityFrameworkCore;
using RentalService.DAL.Contracts;
using RentalService.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalService.DAL.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        private readonly RentalServiceContext db;

        public CityRepository(RentalServiceContext context)
            : base(context)
        {
            db = context;
        }

        public override async Task<City> GetAsync(int? id)
        {
            return await db.Cities
                .Include(c => c.Country)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<IEnumerable<City>> GetAllAsync()
        {
            return await db.Cities
                .Include(c => c.Country)
                .AsNoTracking()
                .ToListAsync();
        }

        public bool CityExists(int id)
        {
            return db.Cities.Any(c => c.Id == id);
        }
    }
}
