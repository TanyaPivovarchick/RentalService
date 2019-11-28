using Microsoft.EntityFrameworkCore;
using RentalService.DAL.Contracts;
using RentalService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalService.DAL.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        private readonly RentalServiceContext db;

        public ReservationRepository(RentalServiceContext context)
            : base(context)
        {
            db = context;
        }

        public override async Task<Reservation> GetAsync(int? id)
        {
            return await db.Reservations
                .Include(r => r.RentalPointCar)
                    .ThenInclude(c => c.Car)
                .Include(r => r.RentalPointCar)
                    .ThenInclude(c => c.RentalPoint)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public IEnumerable<Reservation> GetReservationsForDelete()
        {
            var currentTime = DateTime.Now;

            return db.Reservations
                .Where(r => !r.IsConfirmed)
                .AsEnumerable()
                .Where(r => currentTime.Subtract(r.CreatedOn).TotalMinutes > 5)
                .ToList();
        }

        public void DeleteRange(IEnumerable<Reservation> reservations)
        {
            db.Reservations.RemoveRange(reservations);
        }
    }
}
