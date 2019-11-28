using System;
using System.ComponentModel.DataAnnotations;

namespace RentalService.Web.ViewModels
{
    public class ReservationVM
    {
        public int Id { get; set; }
        public bool IsConfirmed { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int RentalPointCarId { get; set; }
        public RentalPointCarVM RentalPointCar { get; set; }
    }
}
