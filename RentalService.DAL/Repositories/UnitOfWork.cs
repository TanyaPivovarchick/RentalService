﻿using RentalService.DAL.Contracts;
using System;
using System.Threading.Tasks;

namespace RentalService.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentalServiceContext db;

        private ICountryRepository countryRepository;

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
