﻿using System.Collections.Generic;

namespace RentalService.DAL.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
