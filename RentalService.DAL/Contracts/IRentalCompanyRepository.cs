using RentalService.DAL.Entities;

namespace RentalService.DAL.Contracts
{
    public interface IRentalCompanyRepository : IBaseRepository<RentalCompany>
    {
        bool RentalCompanyExists(int id);
    }
}
