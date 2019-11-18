using Microsoft.EntityFrameworkCore;
using RentalService.DAL.Contracts;
using RentalService.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalService.DAL.Repositories
{
    public class RentalPointRepository : BaseRepository<RentalPoint>, IRentalPointRepository
    {
        private readonly RentalServiceContext db;

        public RentalPointRepository(RentalServiceContext context)
            : base(context)
        {
            db = context;
        }

        public override async Task<RentalPoint> GetAsync(int? id)
        {
            return await db.RentalPoints
                .Include(p => p.City)
                .Include(p => p.Company)
                .Include(p => p.RentalPointCars)
                    .ThenInclude(c => c.Car)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<IEnumerable<RentalPoint>> GetAllAsync()
        {
            return await db.RentalPoints
                .Include(p => p.City)
                .Include(p => p.Company)
                .AsNoTracking()
                .ToListAsync();
        }

        public bool RentalPointExists(int id)
        {
            return db.RentalPoints.Any(c => c.Id == id);
        }
    }
}
