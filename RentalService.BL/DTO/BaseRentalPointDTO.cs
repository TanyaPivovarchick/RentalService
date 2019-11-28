namespace RentalService.BL.DTO
{
    public class BaseRentalPointDTO
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public int CityId { get; set; }
        public CityDTO City { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
