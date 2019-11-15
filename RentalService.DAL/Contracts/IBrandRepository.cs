using RentalService.DAL.Entities;

namespace RentalService.DAL.Contracts
{
    public interface IBrandRepository : IBaseRepository<Brand>
    {
        bool BrandExists(int id);
    }
}
