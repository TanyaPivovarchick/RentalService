using Microsoft.EntityFrameworkCore;
using RentalService.DAL.Contracts;
using RentalService.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalService.DAL.Repositories
{
    public class RentalPointCarRepository : BaseRepository<RentalPointCar>, IRentalPointCarRepository
    {
        private readonly RentalServiceContext db;

        public RentalPointCarRepository(RentalServiceContext context)
            : base(context)
        {
            db = context;
        }

        public override async Task<RentalPointCar> GetAsync(int? id)
        {
            return await db.RentalPointCars
                .Include(c => c.RentalPoint)
                .Include(c => c.Car)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<IEnumerable<RentalPointCar>> GetAllAsync()
        {
            return await db.RentalPointCars
                .Include(c => c.RentalPoint)
                .Include(c => c.Car)
                .AsNoTracking()
                .ToListAsync();
        }

        public bool RentalPointCarExists(int id)
        {
            return db.RentalPointCars.Any(c => c.Id == id);
        }
    }
}
