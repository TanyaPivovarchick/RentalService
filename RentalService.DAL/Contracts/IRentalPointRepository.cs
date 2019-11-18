using RentalService.DAL.Entities;

namespace RentalService.DAL.Contracts
{
    public interface IRentalPointRepository : IBaseRepository<RentalPoint>
    {
        bool RentalPointExists(int id);
    }
}
