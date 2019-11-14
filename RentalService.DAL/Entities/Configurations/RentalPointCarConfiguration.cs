using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentalService.DAL.Entities.Configurations
{
    public class RentalPointCarConfiguration : IEntityTypeConfiguration<RentalPointCar>
    {
        public void Configure(EntityTypeBuilder<RentalPointCar> builder)
        {
            builder.HasKey(e => new { e.RentalPointId, e.CarId });

            builder.HasData
            (
                new RentalPointCar() { Cost = 15, Count = 10, CarId = 1, RentalPointId = 1 },
                new RentalPointCar() { Cost = 20, Count = 15, CarId = 1, RentalPointId = 2 },
                new RentalPointCar() { Cost = 31, Count = 23, CarId = 2, RentalPointId = 2 },
                new RentalPointCar() { Cost = 26, Count = 17, CarId = 2, RentalPointId = 3 },
                new RentalPointCar() { Cost = 28, Count = 11, CarId = 2, RentalPointId = 4 },
                new RentalPointCar() { Cost = 35, Count = 5, CarId = 3, RentalPointId = 5 },
                new RentalPointCar() { Cost = 25, Count = 7, CarId = 4, RentalPointId = 5 },
                new RentalPointCar() { Cost = 40, Count = 9, CarId = 5, RentalPointId = 5 }
            );
        }
    }
}
