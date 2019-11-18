using System.Collections.Generic;

namespace RentalService.BL.DTO
{
    public class RentalPointDTO
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public int CityId { get; set; }
        public string CityName { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public ICollection<RentalPointCarDTO> RentalPointCars { get; set; }
    }
}
