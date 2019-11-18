using RentalService.DAL.Contracts;
using System;
using System.Threading.Tasks;

namespace RentalService.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentalServiceContext db;

        private ICountryRepository countryRepository;
        private ICityRepository cityRepository;
        private IBrandRepository brandRepository;
        private ICarRepository carRepository;
        private IRentalCompanyRepository rentalCompanyRepository;
        private IRentalPointRepository rentalPointRepository;
        private IRentalPointCarRepository pointCarRepository;

        private bool disposed = false;

        public UnitOfWork(RentalServiceContext context)
        {
            db = context;
        }

        public ICountryRepository CountryRepository
        {
            get
            {
                return countryRepository ??= new CountryRepository(db);
            }
        }

        public ICityRepository CityRepository
        {
            get
            {
                return cityRepository ??= new CityRepository(db);
            }
        }

        public IBrandRepository BrandRepository
        {
            get
            {
                return brandRepository ??= new BrandRepository(db);
            }
        }

        public ICarRepository CarRepository
        {
            get
            {
                return carRepository ??= new CarRepository(db);
            }
        }

        public IRentalCompanyRepository RentalCompanyRepository
        {
            get
            {
                return rentalCompanyRepository ??= new RentalCompanyRepository(db);
            }
        }

        public IRentalPointRepository RentalPointRepository
        {
            get
            {
                return rentalPointRepository ??= new RentalPointRepository(db);
            }
        }

        public IRentalPointCarRepository PointCarRepository
        {
            get
            {
                return pointCarRepository ??= new RentalPointCarRepository(db);
            }
        }

        public async Task<int> Save()
        {
            return await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                disposed = true;
            }
        }
    }
}
