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
    public class CarService : ICarService
    {
        private readonly IUnitOfWork db;

        public CarService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        public async Task<IEnumerable<CarDTO>> GetAllCarsAsync()
        {
            var cars = await db.CarRepository.GetAllAsync();

            return cars?.Adapt<IEnumerable<CarDTO>>();
        }

        public async Task<CarDTO> GetCarAsync(int? id)
        {
            var car = await db.CarRepository.GetAsync(id);

            if (car == null)
            {
                throw new Exception("Car wasn't found");
            }

            return car.Adapt<CarDTO>();
        }

        public async Task AddCarAsync(CarDTO car)
        {
            db.CarRepository.Add(car.Adapt<Car>());
            await db.Save();
        }

        public async Task UpdateCarAsync(CarDTO car)
        {
            db.CarRepository.Update(car.Adapt<Car>());
            await db.Save();
        }

        public async Task DeleteCarAsync(int id)
        {
            var car = await db.CarRepository.GetAsync(id);

            if (car == null)
            {
                throw new Exception("Car wasn't found");
            }

            db.CarRepository.Delete(car);
            await db.Save();
        }

        public bool CarExists(int id)
        {
            return db.CarRepository.CarExists(id);
        }
    }
}
