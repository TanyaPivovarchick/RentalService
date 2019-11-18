using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalService.Web.ViewModels
{
    public class RentalCompanyVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<RentalPointVM> Points { get; set; }
    }
}
