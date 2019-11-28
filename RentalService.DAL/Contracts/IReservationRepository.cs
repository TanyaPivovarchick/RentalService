using RentalService.DAL.Entities;
using System.Collections.Generic;

namespace RentalService.DAL.Contracts
{
    public interface IReservationRepository : IBaseRepository<Reservation>
    {
        IEnumerable<Reservation> GetReservationsForDelete();
        void DeleteRange(IEnumerable<Reservation> reservations);
    }
}
