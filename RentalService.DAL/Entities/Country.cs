﻿using System.Collections.Generic;

namespace RentalService.DAL.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
