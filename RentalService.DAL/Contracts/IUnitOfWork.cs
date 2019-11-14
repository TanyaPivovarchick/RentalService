using System;
using System.Threading.Tasks;

namespace RentalService.DAL.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Save();
    }
}
