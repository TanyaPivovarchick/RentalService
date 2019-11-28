using System;

namespace RentalService.DAL.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan KeyReceiptTime { get; set; }
        public double Cost { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int RentalPointCarId { get; set; }
        public RentalPointCar RentalPointCar { get; set; }
    }
}
