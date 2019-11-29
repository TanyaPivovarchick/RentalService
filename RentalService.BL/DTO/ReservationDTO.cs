using System;

namespace RentalService.BL.DTO
{
    [Serializable]
    public class ReservationDTO
    {
        public int Id { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan KeyReceiptTime { get; set; }
        public TimeSpan KeyReturnTime { get; set; }
        public double Cost { get; set; }

        public int UserId { get; set; }

        public int RentalPointCarId { get; set; }
        public RentalPointCarDTO RentalPointCar { get; set; }
    }
}
