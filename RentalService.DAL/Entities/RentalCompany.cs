using System.Collections.Generic;

namespace RentalService.DAL.Entities
{
    public class RentalCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RentalPoint> Points { get; set; }
    }
}
