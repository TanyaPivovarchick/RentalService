namespace RentalService.DAL.Entities
{
    public class RentalPointCar
    {
        public double Cost { get; set; }
        public int Count { get; set; }

        public int RentalPointId { get; set; }
        public RentalPoint RentalPoint { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
