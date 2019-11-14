using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalService.ViewModels
{
    public class CountryVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        public ICollection<CityVM> Cities { get; set; }
    }
}
