using Microsoft.EntityFrameworkCore;
using RentalService.DAL.Contracts;
using RentalService.DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace RentalService.DAL.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        private readonly RentalServiceContext db;

        public CountryRepository(RentalServiceContext context)
            : base(context)
        {
            db = context;
        }

        public override async Task<Country> GetAsync(int? id)
        {
            return await db.Countries
                .Include(c => c.Cities)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public bool CountryExists(int id)
        {
            return db.Countries.Any(c => c.Id == id);
        }
    }
}
