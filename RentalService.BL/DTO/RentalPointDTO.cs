using System.Collections.Generic;

namespace RentalService.BL.DTO
{
    public class RentalPointDTO : BaseRentalPointDTO
    {
        public ICollection<RentalPointCarDTO> RentalPointCars { get; set; }
    }
}
