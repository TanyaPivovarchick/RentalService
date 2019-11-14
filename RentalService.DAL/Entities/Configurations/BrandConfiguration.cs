using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentalService.DAL.Entities.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData
            (
                new Brand() { Id = 1, Name = "BMW" },
                new Brand() { Id = 2, Name = "Toyota" },
                new Brand() { Id = 3, Name = "Audi" },
                new Brand() { Id = 4, Name = "Bentley" },
                new Brand() { Id = 5, Name = "Nissan" }
            );
        }
    }
}
