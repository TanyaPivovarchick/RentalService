using System;
using System.ComponentModel.DataAnnotations;

namespace RentalService.Web.ViewModels.Filters
{
    public class RentalPointCarFilterVM
    {
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        public string Country { get; set; }
        public string City { get; set; }

        [Display(Name = "Company")]
        public string RentalCompany { get; set; }
    }
}
