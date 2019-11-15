namespace RentalService.BL.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SeatCount { get; set; }
        public double FuelConsumption { get; set; }

        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
