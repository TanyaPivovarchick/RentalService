using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentalService.DAL.Entities.Configurations
{
    public class RentalPointCarConfiguration : IEntityTypeConfiguration<RentalPointCar>
    {
        public void Configure(EntityTypeBuilder<RentalPointCar> builder)
        {
            builder.HasData
            (
                new RentalPointCar() { Id= 1, Cost = 15, Count = 10, CarId = 1, RentalPointId = 1 },
                new RentalPointCar() { Id = 2, Cost = 20, Count = 15, CarId = 1, RentalPointId = 2 },
                new RentalPointCar() { Id = 3, Cost = 31, Count = 23, CarId = 2, RentalPointId = 2 },
                new RentalPointCar() { Id = 4, Cost = 26, Count = 17, CarId = 2, RentalPointId = 3 },
                new RentalPointCar() { Id = 5, Cost = 28, Count = 11, CarId = 2, RentalPointId = 4 },
                new RentalPointCar() { Id = 6, Cost = 35, Count = 5, CarId = 3, RentalPointId = 5 },
                new RentalPointCar() { Id = 7, Cost = 25, Count = 7, CarId = 4, RentalPointId = 5 },
                new RentalPointCar() { Id = 8, Cost = 40, Count = 9, CarId = 5, RentalPointId = 5 }
            );

            builder
                .HasOne(c => c.RentalPoint)
                .WithMany(p => p.RentalPointCars);
        }
    }
}
