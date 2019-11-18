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
    public class RentalPointCarService : IRentalPointCarService
    {
        private readonly IUnitOfWork db;

        public RentalPointCarService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        public async Task<IEnumerable<RentalPointCarDTO>> GetAllRentalPointCarsAsync()
        {
            var rentalPointCars = await db.PointCarRepository.GetAllAsync();

            return rentalPointCars?.Adapt<IEnumerable<RentalPointCarDTO>>();
        }

        public async Task<RentalPointCarDTO> GetRentalPointCarAsync(int? id)
        {
            var rentalPointCar = await db.PointCarRepository.GetAsync(id);

            if (rentalPointCar == null)
            {
                throw new Exception("Rental point wasn't found");
            }

            return rentalPointCar.Adapt<RentalPointCarDTO>();
        }

        public async Task AddRentalPointCarAsync(RentalPointCarDTO rentalPointCar)
        {
            db.PointCarRepository.Add(rentalPointCar.Adapt<RentalPointCar>());
            await db.Save();
        }

        public async Task UpdateRentalPointCarAsync(RentalPointCarDTO rentalPointCar)
        {
            db.PointCarRepository.Update(rentalPointCar.Adapt<RentalPointCar>());
            await db.Save();
        }

        public async Task DeleteRentalPointCarAsync(int id)
        {
            var rentalPointCar = await db.PointCarRepository.GetAsync(id);

            if (rentalPointCar == null)
            {
                throw new Exception("Rental point wasn't found");
            }

            db.PointCarRepository.Delete(rentalPointCar);
            await db.Save();
        }

        public bool RentalPointCarExists(int id)
        {
            return db.PointCarRepository.RentalPointCarExists(id);
        }
    }
}
