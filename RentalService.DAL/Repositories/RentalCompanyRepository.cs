using Microsoft.EntityFrameworkCore;
using RentalService.DAL.Contracts;
using RentalService.DAL.Entities;
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

        public bool RentalCompanyExists(int id)
        {
            return db.RentalCompanies.Any(c => c.Id == id);
        }
    }
}
