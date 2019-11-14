using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentalService.DAL.Entities.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData
            (
                new Car() { Id = 1, Name = "BMW X6", SeatCount = 5, FuelConsumption = 9, BrandId = 1 },
                new Car() { Id = 2, Name = "BMW X7", SeatCount = 5, FuelConsumption = 7.9, BrandId = 1 },
                new Car() { Id = 3, Name = "BMW X7", SeatCount = 7, FuelConsumption = 9.1, BrandId = 1 },
                new Car() { Id = 4, Name = "Audi Q7", SeatCount = 5, FuelConsumption = 6, BrandId = 3 },
                new Car() { Id = 5, Name = "Nissan Armada", SeatCount = 8, FuelConsumption = 18, BrandId = 5 }
            );
        }
    }
}
