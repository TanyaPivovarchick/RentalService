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
    public class RentalCompanyService : IRentalCompanyService
    {
        private readonly IUnitOfWork db;

        public RentalCompanyService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        public async Task<IEnumerable<RentalCompanyDTO>> GetAllRentalCompaniesAsync()
        {
            var rentalCompanies = await db.RentalCompanyRepository.GetAllAsync();

            return rentalCompanies?.Adapt<IEnumerable<RentalCompanyDTO>>();
        }

        public async Task<RentalCompanyDTO> GetRentalCompanyAsync(int? id)
        {
            var rentalCompany = await db.RentalCompanyRepository.GetAsync(id);

            if (rentalCompany == null)
            {
                throw new Exception("Сountry wasn't found");
            }

            return rentalCompany.Adapt<RentalCompanyDTO>();
        }

        public async Task<IEnumerable<RentalCompanyDTO>> FindRentalCompaniesAsync(string searchString, string cityName)
        {
            var rentalCompanies = await db.RentalCompanyRepository.FindAsync(searchString, cityName);

            return rentalCompanies?.Adapt<IEnumerable<RentalCompanyDTO>>();
        }

        public async Task AddRentalCompanyAsync(RentalCompanyDTO rentalCompany)
        {
            db.RentalCompanyRepository.Add(rentalCompany.Adapt<RentalCompany>());
            await db.Save();
        }

        public async Task UpdateRentalCompanyAsync(RentalCompanyDTO rentalCompany)
        {
            db.RentalCompanyRepository.Update(rentalCompany.Adapt<RentalCompany>());
            await db.Save();
        }

        public async Task DeleteRentalCompanyAsync(int id)
        {
            var rentalCompany = await db.RentalCompanyRepository.GetAsync(id);

            if (rentalCompany == null)
            {
                throw new Exception("Сountry wasn't found");
            }

            db.RentalCompanyRepository.Delete(rentalCompany);
            await db.Save();
        }

        public bool RentalCompanyExists(int id)
        {
            return db.RentalCompanyRepository.RentalCompanyExists(id);
        }
    }
}
