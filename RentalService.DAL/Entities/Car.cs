using System.Collections.Generic;

namespace RentalService.DAL.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SeatCount { get; set; }
        public double FuelConsumption { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public ICollection<RentalPointCar> RentalPointCars { get; set; }
    }
}
