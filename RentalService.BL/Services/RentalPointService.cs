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
    public class RentalPointService : IRentalPointService
    {
        private readonly IUnitOfWork db;

        public RentalPointService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        public async Task<IEnumerable<RentalPointDTO>> GetAllRentalPointsAsync()
        {
            var rentalPoints = await db.RentalPointRepository.GetAllAsync();

            return rentalPoints?.Adapt<IEnumerable<RentalPointDTO>>();
        }

        public async Task<RentalPointDTO> GetRentalPointAsync(int? id)
        {
            var rentalPoint = await db.RentalPointRepository.GetAsync(id);

            if (rentalPoint == null)
            {
                throw new Exception("Rental point wasn't found");
            }

            return rentalPoint.Adapt<RentalPointDTO>();
        }

        public async Task AddRentalPointAsync(RentalPointDTO rentalPoint)
        {
            db.RentalPointRepository.Add(rentalPoint.Adapt<RentalPoint>());
            await db.Save();
        }

        public async Task UpdateRentalPointAsync(RentalPointDTO rentalPoint)
        {
            db.RentalPointRepository.Update(rentalPoint.Adapt<RentalPoint>());
            await db.Save();
        }

        public async Task DeleteRentalPointAsync(int id)
        {
            var rentalPoint = await db.RentalPointRepository.GetAsync(id);

            if (rentalPoint == null)
            {
                throw new Exception("Rental point wasn't found");
            }

            db.RentalPointRepository.Delete(rentalPoint);
            await db.Save();
        }

        public bool RentalPointExists(int id)
        {
            return db.RentalPointRepository.RentalPointExists(id);
        }
    }
}
