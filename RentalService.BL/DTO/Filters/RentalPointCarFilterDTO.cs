using System;

namespace RentalService.BL.DTO.Filters
{
    public class RentalPointCarFilterDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string RentalCompany { get; set; }
    }
}
