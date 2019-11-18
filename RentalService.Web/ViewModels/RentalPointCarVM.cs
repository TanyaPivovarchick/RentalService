using System.ComponentModel.DataAnnotations;

namespace RentalService.Web.ViewModels
{
    public class RentalPointCarVM
    {
        public int Id { get; set; }

        [Required]
        public double Cost { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public int RentalPointId { get; set; }

        [Display(Name = "Address")]
        public string RentalPointAddress { get; set; }

        [Required]
        public int CarId { get; set; }

        [Display(Name = "Car")]
        public string CarName { get; set; }
    }
}
