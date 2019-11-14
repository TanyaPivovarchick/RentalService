using System.Collections.Generic;

namespace RentalService.BL.DTO
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<CityDTO> Cities { get; set; }
    }
}
