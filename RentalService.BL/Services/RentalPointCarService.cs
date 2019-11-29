using Mapster;
using Microsoft.EntityFrameworkCore;
using RentalService.BL.Contracts;
using RentalService.BL.DTO;
using RentalService.BL.DTO.Filters;
using RentalService.DAL.Contracts;
using RentalService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<RentalPointCarDTO> GetRentalPointCarAsync(int? id)
        {
            var rentalPointCar = await db.PointCarRepository.GetAsync(id);

            if (rentalPointCar == null)
            {
                throw new Exception("Rental point wasn't found");
            }

            return rentalPointCar.Adapt<RentalPointCarDTO>();
        }

        public async Task<IEnumerable<RentalPointCarDTO>> SearchAsync(RentalPointCarFilterDTO filter)
        {
            var rentalPointCars = await db.PointCarRepository
                .SearchAsync(filter.Country, filter.City, filter.RentalCompany);

            var rentalPointCarsDTO = rentalPointCars
                .Select(c =>
                {
                    var reservedCount = c.Reservations
                        .Where(r => r.RentalPointCarId == c.Id && !(r.EndDate < filter.StartDate ||
                            r.StartDate > filter.EndDate))
                        .Count();

                    var dtoObj = c.Adapt<RentalPointCarDTO>();
                    dtoObj.Count -= reservedCount;
                    return dtoObj;
                })
                .Where(c => c.Count > 0);

            return rentalPointCarsDTO;
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
