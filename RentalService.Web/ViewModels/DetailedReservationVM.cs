using System;
using System.ComponentModel.DataAnnotations;

namespace RentalService.Web.ViewModels
{
    public class DetailedReservationVM : ReservationVM
    {
        [Required]
        public TimeSpan KeyReceiptTime { get; set; }

        [Required]
        public TimeSpan KeyReturnTime { get; set; }

        public double Cost { get; set; }
    }
}
