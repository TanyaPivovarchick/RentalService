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

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<RentalCompany> RentalCompanies { get; set; }
        public DbSet<RentalPoint> RentalPoints { get; set; }
        public DbSet<RentalPointCar> RentalPointCars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new RentalCompanyConfiguration());
            modelBuilder.ApplyConfiguration(new RentalPointCarConfiguration());
            modelBuilder.ApplyConfiguration(new RentalPointConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
