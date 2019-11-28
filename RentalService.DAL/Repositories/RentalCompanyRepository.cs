using Microsoft.EntityFrameworkCore;
using RentalService.DAL.Contracts;
using RentalService.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalService.DAL.Repositories
{
    public class RentalCompanyRepository : BaseRepository<RentalCompany>, IRentalCompanyRepository
    {
        private readonly RentalServiceContext db;

        public RentalCompanyRepository(RentalServiceContext context)
            : base(context)
        {
            db = context;
        }

        public override async Task<RentalCompany> GetAsync(int? id)
        {
            return await db.RentalCompanies
                .Include(c => c.Points)
                    .ThenInclude(p => p.City)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<RentalCompany>> FindAsync(string searchString, string cityName)
        {
            var companies = db.RentalCompanies
                .Include(c => c.Points)
                    .ThenInclude(p => p.City)
                .AsNoTracking()
                .Where(c => c.Points.Any(p => p.City.Name == cityName));


            if (!string.IsNullOrWhiteSpace(searchString))
            {
                companies = companies.Where(c => c.Name.Contains(searchString));
            }

            return await companies.ToListAsync();
        }

        public bool RentalCompanyExists(int id)
        {
            return db.RentalCompanies.Any(c => c.Id == id);
        }
    }
}
