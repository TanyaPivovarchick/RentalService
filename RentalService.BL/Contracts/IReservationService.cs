using RentalService.BL.DTO;
using System;
using System.Threading.Tasks;

namespace RentalService.BL.Contracts
{
    public interface IReservationService
    {
        Task<ReservationDTO> GetReservationAsync(int id);
        Task<ReservationDTO> AddReservationAsync(string userEmail, int carId, DateTime startDate, DateTime endDate);
        Task SetKeyReceiptTimeAsync(int id, TimeSpan time);
        Task ConfirmRentalAsync(int id, double cost);
        Task DeleteUnconfirmedRentals();
    }
}
