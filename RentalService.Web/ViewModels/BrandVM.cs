using System.ComponentModel.DataAnnotations;

namespace RentalService.Web.ViewModels
{
    public class BrandVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
