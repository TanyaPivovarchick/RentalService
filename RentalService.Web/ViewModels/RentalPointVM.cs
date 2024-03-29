﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalService.Web.ViewModels
{
    public class RentalPointVM
    {
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int CityId { get; set; }
        public CityVM City { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [Display(Name = "Cars")]
        public virtual ICollection<RentalPointCarVM> RentalPointCars { get; set; }
    }
}
