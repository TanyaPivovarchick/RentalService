using Mapster;
using RentalService.BL.Contracts;
using RentalService.BL.DTO;
using RentalService.DAL.Contracts;
using RentalService.DAL.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RentalService.BL.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork db;

        public ReservationService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        public async Task<ReservationDTO> GetReservationAsync(int id)
        {
            var reservation = await db.ReservationRepository.GetAsync(id);

            if (reservation == null)
            {
                throw new Exception("Reservation wasn't found");
            }

            int dayCount = reservation.EndDate.Subtract(reservation.StartDate).Days;

            var reservationDTO = reservation.Adapt<ReservationDTO>();
            reservationDTO.Cost = dayCount * reservationDTO.RentalPointCar.Cost;

            return reservationDTO;
        }

        public async Task<ReservationDTO> AddReservationAsync(string userEmail, int carId, DateTime startDate, DateTime endDate)
        {
            var user = await db.UserRepository.GetUserAsync(userEmail);

            var car = await db.PointCarRepository.GetAsync(carId);
            if (car == null || car.Count == 0)
            {
                throw new Exception("This car is not available for rental");
            }

            int dayCount = endDate.Subtract(startDate).Days;
            if (dayCount <= 0 || startDate.Subtract(DateTime.Now).Days < 0)
            {
                throw new Exception("Wrong dates");
            }

            var reservationDTO = new ReservationDTO()
            {
                IsConfirmed = false,
                CreatedOn = DateTime.Now,
                StartDate = startDate,
                EndDate = endDate,
                RentalPointCarId = carId,
                UserId = user.Id
            };

            var entity = reservationDTO.Adapt<Reservation>();

            db.ReservationRepository.Add(entity);
            await db.Save();

            reservationDTO.Id = entity.Id;

            return reservationDTO;
        }

        public async Task SetKeyReceiptTimeAsync(int id, TimeSpan time)
        {
            var reservation = await db.ReservationRepository.GetAsync(id);

            reservation.KeyReceiptTime = time;

            db.ReservationRepository.Update(reservation);
            await db.Save();
        }

        public async Task ConfirmRentalAsync(int id, double cost)
        {
            var reservation = await db.ReservationRepository.GetAsync(id);

            reservation.Cost = cost;
            reservation.IsConfirmed = true;

            db.ReservationRepository.Update(reservation);
            await db.Save();
        }

        public async Task DeleteUnconfirmedRentals()
        {
            var reservations = db.ReservationRepository.GetReservationsForDelete();

            if (reservations.Count() != 0)
            {
                db.ReservationRepository.DeleteRange(reservations);
                await db.Save();
            }
        }
    }
}
