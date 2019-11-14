using System.ComponentModel.DataAnnotations;

namespace RentalService.Web.ViewModels
{
    public class CityVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Display(Name = "Country")]
        public string CountryName { get; set; }
    }
}
