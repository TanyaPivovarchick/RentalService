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
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork db;

        public BrandService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        public async Task<IEnumerable<BrandDTO>> GetAllBrandsAsync()
        {
            var brands = await db.BrandRepository.GetAllAsync();

            return brands?.Adapt<IEnumerable<BrandDTO>>();
        }

        public async Task<BrandDTO> GetBrandAsync(int? id)
        {
            var brand = await db.BrandRepository.GetAsync(id);

            if (brand == null)
            {
                throw new Exception("Brand wasn't found");
            }

            return brand.Adapt<BrandDTO>();
        }

        public async Task AddBrandAsync(BrandDTO brand)
        {
            db.BrandRepository.Add(brand.Adapt<Brand>());
            await db.Save();
        }

        public async Task UpdateBrandAsync(BrandDTO brand)
        {
            db.BrandRepository.Update(brand.Adapt<Brand>());
            await db.Save();
        }

        public async Task DeleteBrandAsync(int id)
        {
            var brand = await db.BrandRepository.GetAsync(id);

            if (brand == null)
            {
                throw new Exception("Brand wasn't found");
            }

            db.BrandRepository.Delete(brand);
            await db.Save();
        }

        public bool BrandExists(int id)
        {
            return db.BrandRepository.BrandExists(id);
        }
    }
}
