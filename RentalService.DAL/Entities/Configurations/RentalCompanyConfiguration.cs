using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentalService.DAL.Entities.Configurations
{
    public class RentalCompanyConfiguration : IEntityTypeConfiguration<RentalCompany>
    {
        public void Configure(EntityTypeBuilder<RentalCompany> builder)
        {
            builder.HasData
            (
                new RentalCompany() { Id = 1, Name = "Europcar" },
                new RentalCompany() { Id = 2, Name = "Sixt" }
            );
        }
    }
}
