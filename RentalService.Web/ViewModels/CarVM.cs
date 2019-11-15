using System.ComponentModel.DataAnnotations;

namespace RentalService.Web.ViewModels
{
    public class CarVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Seat count")]
        public int SeatCount { get; set; }

        [Required]
        [Display(Name = "Fuel consumption")]
        public double FuelConsumption { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Display(Name = "Brand")]
        public string BrandName { get; set; }
    }
}
