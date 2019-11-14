using System;
using System.Threading.Tasks;

namespace RentalService.DAL.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ICountryRepository CountryRepository { get; }
        ICityRepository CityRepository { get; }

        Task<int> Save();
    }
}
