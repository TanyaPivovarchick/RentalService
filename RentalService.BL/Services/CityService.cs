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
    public class CityService : ICityService
    {
        private readonly IUnitOfWork db;

        public CityService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        public async Task<IEnumerable<CityDTO>> GetAllCitiesAsync()
        {
            var cities = await db.CityRepository.GetAllAsync();

            return cities?.Adapt<IEnumerable<CityDTO>>();
        }

        public async Task<CityDTO> GetCityAsync(int? id)
        {
            var city = await db.CityRepository.GetAsync(id);

            if (city == null)
            {
                throw new Exception("City wasn't found");
            }

            return city.Adapt<CityDTO>();
        }

        public async Task<IEnumerable<CityDTO>> FindCitiesAsync(string searchString, string countryName)
        {
            var cities = await db.CityRepository.FindAsync(searchString, countryName);

            return cities?.Adapt<IEnumerable<CityDTO>>();
        }

        public async Task AddCityAsync(CityDTO city)
        {
            db.CityRepository.Add(city.Adapt<City>());
            await db.Save();
        }

        public async Task UpdateCityAsync(CityDTO city)
        {
            db.CityRepository.Update(city.Adapt<City>());
            await db.Save();
        }

        public async Task DeleteCityAsync(int id)
        {
            var city = await db.CityRepository.GetAsync(id);

            if (city == null)
            {
                throw new Exception("City wasn't found");
            }

            db.CityRepository.Delete(city);
            await db.Save();
        }

        public bool CityExists(int id)
        {
            return db.CityRepository.CityExists(id);
        }
    }
}
