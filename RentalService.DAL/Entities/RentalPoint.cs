using System.Collections.Generic;

namespace RentalService.DAL.Entities
{
    public class RentalPoint
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public int CompanyId { get; set; }
        public RentalCompany Company { get; set; }

        public ICollection<RentalPointCar> RentalPointCars { get; set; }
    }
}
