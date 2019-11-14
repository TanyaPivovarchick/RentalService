using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentalService.DAL.Entities.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData
            (
                new City() { Id = 1, Name = "Barcelona", CountryId = 1 },
                new City() { Id = 2, Name = "Madrid", CountryId = 1 },
                new City() { Id = 3, Name = "Alicante", CountryId = 1 },
                new City() { Id = 4, Name = "Lisbon", CountryId = 2 },
                new City() { Id = 5, Name = "Porto", CountryId = 2 }
            );
        }
    }
}
