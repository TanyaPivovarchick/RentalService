using RentalService.DAL.Entities;

namespace RentalService.DAL.Contracts
{
    public interface IRentalPointCarRepository : IBaseRepository<RentalPointCar>
    {
        bool RentalPointCarExists(int id);
    }
}
