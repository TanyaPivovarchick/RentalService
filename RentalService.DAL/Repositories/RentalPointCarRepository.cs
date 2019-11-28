using Microsoft.EntityFrameworkCore;
using RentalService.DAL.Contracts;
using RentalService.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalService.DAL.Repositories
{
    public class RentalPointCarRepository : BaseRepository<RentalPointCar>, IRentalPointCarRepository
    {
        private readonly RentalServiceContext db;

        public RentalPointCarRepository(RentalServiceContext context)
            : base(context)
        {
            db = context;
        }

        public override async Task<RentalPointCar> GetAsync(int? id)
        {
            return await db.RentalPointCars
                .Include(c => c.RentalPoint)
                .Include(c => c.Car)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<IEnumerable<RentalPointCar>> GetAllAsync()
        {
            return await db.RentalPointCars
                .Include(c => c.RentalPoint)
                    .ThenInclude(p => p.City)
                        .ThenInclude(c => c.Country)
                .Include(c => c.RentalPoint)
                    .ThenInclude(p => p.Company)
                .Include(c => c.Car)
                .ToListAsync();
        }

        public async Task<IEnumerable<RentalPointCar>> SearchAsync(string countryName, string cityName, string companyName)
        {
            var rentalCars = db.RentalPointCars
                .Include(c => c.RentalPoint)
                    .ThenInclude(p => p.City)
                        .ThenInclude(c => c.Country)
                .Include(c => c.RentalPoint)
                    .ThenInclude(p => p.Company)
                .Include(c => c.Car)
                .Include(c => c.Reservations)
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(countryName))
            {
                rentalCars = rentalCars.Where(c => c.RentalPoint.City.Country.Name == countryName);

                if (!string.IsNullOrWhiteSpace(cityName))
                {
                    rentalCars = rentalCars.Where(c => c.RentalPoint.City.Name == cityName);

                    if (!string.IsNullOrWhiteSpace(companyName))
                    {
                        rentalCars = rentalCars.Where(c => c.RentalPoint.Company.Name == companyName);
                    }
                }
            }

            return await rentalCars.ToListAsync();
        }

        public bool RentalPointCarExists(int id)
        {
            return db.RentalPointCars.Any(c => c.Id == id);
        }
    }
}
