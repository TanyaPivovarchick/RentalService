using System;
using System.Threading.Tasks;

namespace RentalService.DAL.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ICountryRepository CountryRepository { get; }
        ICityRepository CityRepository { get; }
        IBrandRepository BrandRepository { get; }
        ICarRepository CarRepository { get; }
        IRentalCompanyRepository RentalCompanyRepository { get; }
        IRentalPointRepository RentalPointRepository { get; }
        IRentalPointCarRepository PointCarRepository { get; }

        Task<int> Save();
    }
}
