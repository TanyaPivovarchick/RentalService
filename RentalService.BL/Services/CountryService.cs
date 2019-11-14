using Mapster;
using RentalService.BL.Contracts;
using RentalService.BL.DTO;
using RentalService.DAL.Contracts;
using RentalService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalService.BL.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork db;

        public CountryService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        public async Task<IEnumerable<CountryDTO>> GetAllCountriesAsync()
        {
            var countries = await db.CountryRepository.GetAllAsync();

            return countries?.Adapt<IEnumerable<CountryDTO>>();
        }

        public async Task<CountryDTO> GetCountryAsync(int? id)
        {
            var country = await db.CountryRepository.GetAsync(id);

            if (country == null)
            {
                throw new Exception("Сountry wasn't found");
            }

            return country.Adapt<CountryDTO>();
        }

        public async Task AddCountry(CountryDTO country)
        {
            db.CountryRepository.Add(country.Adapt<Country>());
            await db.Save();
        }

        public async Task UpdateCountry(CountryDTO country)
        {
            db.CountryRepository.Update(country.Adapt<Country>());
            await db.Save();
        }

        public async Task DeleteCountry(int id)
        {
            var country = await db.CountryRepository.GetAsync(id);

            if (country == null)
            {
                throw new Exception("Сountry wasn't found");
            }

            db.CountryRepository.Delete(country);
            await db.Save();
        }

        public bool CountryExists(int id)
        {
            return db.CountryRepository.CountryExists(id);
        }
    }
}
