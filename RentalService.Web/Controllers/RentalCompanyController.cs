using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalService.BL.Contracts;
using RentalService.BL.DTO;
using RentalService.Web.ViewModels;

namespace RentalService.Web.Controllers
{
    public class RentalCompanyController : Controller
    {
        private readonly IRentalCompanyService service;

        public RentalCompanyController(IRentalCompanyService rentalCompanyService)
        {
            service = rentalCompanyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var countries = await service.GetAllRentalCompaniesAsync();

            return View(countries?.Adapt<IEnumerable<RentalCompanyVM>>());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("Rental company ID wasn't set");
            }

            try
            {
                var rentalCompany = await service.GetRentalCompanyAsync(id);

                return View(rentalCompany.Adapt<RentalCompanyVM>());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RentalCompanyVM rentalCompany)
        {
            if (ModelState.IsValid)
            {
                await service.AddRentalCompanyAsync(rentalCompany.Adapt<RentalCompanyDTO>());

                return RedirectToAction(nameof(Index));
            }

            return View(rentalCompany);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest("Rental company ID wasn't set");
            }

            try
            {
                var rentalCompany = await service.GetRentalCompanyAsync(id);

                return View(rentalCompany.Adapt<RentalCompanyVM>());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RentalCompanyVM rentalCompany)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await service.UpdateRentalCompanyAsync(rentalCompany.Adapt<RentalCompanyDTO>());
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalCompanyExists(rentalCompany.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(rentalCompany);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Rental company ID wasn't set");
            }

            try
            {
                var rentalCompany = await service.GetRentalCompanyAsync(id);

                return View(rentalCompany.Adapt<RentalCompanyVM>());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await service.DeleteRentalCompanyAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private bool RentalCompanyExists(int id)
        {
            return service.RentalCompanyExists(id);
        }
    }
}
