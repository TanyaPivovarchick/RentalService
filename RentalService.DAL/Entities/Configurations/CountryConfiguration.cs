using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentalService.DAL.Entities.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData
            (
                new Country() { Id = 1, Name = "Spain", Code = "ES" },
                new Country() { Id = 2, Name = "Portugal", Code = "PT" }
            );
        }
    }
}
