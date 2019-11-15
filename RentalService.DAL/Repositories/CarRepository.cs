using Microsoft.EntityFrameworkCore;
using RentalService.DAL.Contracts;
using RentalService.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalService.DAL.Repositories
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        private readonly RentalServiceContext db;

        public CarRepository(RentalServiceContext context)
            : base(context)
        {
            db = context;
        }

        public override async Task<Car> GetAsync(int? id)
        {
            return await db.Cars
                .Include(c => c.Brand)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await db.Cars
                .Include(c => c.Brand)
                .AsNoTracking()
                .ToListAsync();
        }

        public bool CarExists(int id)
        {
            return db.Cars.Any(c => c.Id == id);
        }
    }
}
