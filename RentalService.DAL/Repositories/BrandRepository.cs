using RentalService.DAL.Contracts;
using RentalService.DAL.Entities;
using System.Linq;

namespace RentalService.DAL.Repositories
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        private readonly RentalServiceContext db;

        public BrandRepository(RentalServiceContext context)
            : base(context)
        {
            db = context;
        }

        public bool BrandExists(int id)
        {
            return db.Brands.Any(c => c.Id == id);
        }
    }
}
