using Microsoft.EntityFrameworkCore;
using RentalService.DAL.Entities;
using RentalService.DAL.Entities.Configurations;

namespace RentalService.DAL
{
    public class RentalServiceContext : DbContext
    {
        public RentalServiceContext()
        {
        }

        public RentalServiceContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
        }
    }
}
