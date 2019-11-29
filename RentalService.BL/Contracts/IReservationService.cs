using RentalService.BL.DTO;
using System;
using System.Threading.Tasks;

namespace RentalService.BL.Contracts
{
    public interface IReservationService
    {
        Task<ReservationDTO> GetReservationAsync(int id);
        Task<ReservationDTO> AddReservationAsync(string userEmail, int carId, DateTime startDate, DateTime endDate);
        Task SetTimeForKeyAsync(int id, TimeSpan receiptTime, TimeSpan returnTime);
        Task ConfirmRentalAsync(int id, double cost);
        Task DeleteUnconfirmedRentals();
    }
}
