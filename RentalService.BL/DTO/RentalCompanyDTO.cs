using System.Collections.Generic;

namespace RentalService.BL.DTO
{
    public class RentalCompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RentalPointDTO> Points { get; set; }
    }
}
