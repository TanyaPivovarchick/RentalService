using System.Collections.Generic;

namespace RentalService.DAL.Entities
{
    public class RentalPointCar
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        public int Count { get; set; }

        public int RentalPointId { get; set; }
        public RentalPoint RentalPoint { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
