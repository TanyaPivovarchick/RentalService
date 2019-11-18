namespace RentalService.BL.DTO
{
    public class RentalPointCarDTO
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        public int Count { get; set; }

        public int RentalPointId { get; set; }
        public string RentalPointAddress { get; set; }

        public int CarId { get; set; }
        public string CarName { get; set; }
    }
}
