using RentalService.DAL.Entities;

namespace RentalService.DAL.Contracts
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        bool CarExists(int id);
    }
}
