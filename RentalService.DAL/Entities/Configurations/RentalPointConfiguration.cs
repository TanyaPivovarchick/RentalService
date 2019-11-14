using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentalService.DAL.Entities.Configurations
{
    public class RentalPointConfiguration : IEntityTypeConfiguration<RentalPoint>
    {
        public void Configure(EntityTypeBuilder<RentalPoint> builder)
        {
            builder.HasData
            (
                new RentalPoint() { Id = 1, Address = "GV DE LES CORTS CATALANES 680", CityId = 1, CompanyId = 1 },
                new RentalPoint() { Id = 2, Address = "AVDA HISPANIDAD S/N LLEGADAS", CityId = 2, CompanyId = 1 },
                new RentalPoint() { Id = 3, Address = "ED.GARE DO ORIENTE,LG.G-206", CityId = 4, CompanyId = 1 },
                new RentalPoint() { Id = 4, Address = "Plaza de la Puerta del Mar,3", CityId = 3, CompanyId = 2 },
                new RentalPoint() { Id = 5, Address = "Rua do Barreiro 65", CityId = 5, CompanyId = 2 }
            );
        }
    }
}
