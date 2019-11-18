using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalService.BL.Contracts;
using RentalService.BL.DTO;
using RentalService.Web.ViewModels;

namespace RentalService.Web.Controllers
{
    public class RentalPointController : Controller
    {
        private readonly IRentalPointService rentalPointService;
        private readonly IRentalCompanyService companyService;
        private readonly ICityService cityService;

        public RentalPointController(IRentalPointService rentalPointService, IRentalCompanyService companyService, ICityService cityService)
        {
            this.rentalPointService = rentalPointService;
            this.companyService = companyService;
            this.cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var rentalPoints = await rentalPointService.GetAllRentalPointsAsync();

            return View(rentalPoints?.Adapt<IEnumerable<RentalPointVM>>());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("Rental point ID wasn't set");
            }

            try
            {
                var rentalPoint = await rentalPointService.GetRentalPointAsync(id);

                return View(rentalPoint.Adapt<RentalPointVM>());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? companyId, string companyName)
        {
            if (companyId == null)
            {
                var companies = await companyService.GetAllRentalCompaniesAsync();
                ViewData["Companies"] = new SelectList(companies, "Id", "Name");
            }
            else
            {
                ViewData["CompanyId"] = companyId;
                ViewData["CompanyName"] = companyName;
            }

            var cities = await cityService.GetAllCitiesAsync();
            ViewData["Cities"] = new SelectList(cities, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RentalPointVM rentalPoint)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await rentalPointService.UpdateRentalPointAsync(rentalPoint.Adapt<RentalPointDTO>());
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalPointExists(rentalPoint.Id))
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

            var companies = await companyService.GetAllRentalCompaniesAsync();
            ViewData["Companies"] = new SelectList(companies, "Id", "Name");

            var cities = await cityService.GetAllCitiesAsync();
            ViewData["Cities"] = new SelectList(cities, "Id", "Name");

            return View(rentalPoint);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest("Rental point ID wasn't set");
            }

            try
            {
                var rentalPoint = await rentalPointService.GetRentalPointAsync(id);

                var companies = await companyService.GetAllRentalCompaniesAsync();
                ViewData["Companies"] = new SelectList(companies, "Id", "Name");

                var cities = await cityService.GetAllCitiesAsync();
                ViewData["Cities"] = new SelectList(cities, "Id", "Name");

                return View(rentalPoint.Adapt<RentalPointVM>());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RentalPointVM rentalPoint)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await rentalPointService.UpdateRentalPointAsync(rentalPoint.Adapt<RentalPointDTO>());
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalPointExists(rentalPoint.Id))
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

            var companies = await companyService.GetAllRentalCompaniesAsync();
            ViewData["Companies"] = new SelectList(companies, "Id", "Name");

            var cities = await cityService.GetAllCitiesAsync();
            ViewData["Cities"] = new SelectList(cities, "Id", "Name");

            return View(rentalPoint);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Rental point ID wasn't set");
            }

            try
            {
                var rentalPoint = await rentalPointService.GetRentalPointAsync(id);

                return View(rentalPoint.Adapt<RentalPointVM>());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await rentalPointService.DeleteRentalPointAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private bool RentalPointExists(int id)
        {
            return rentalPointService.RentalPointExists(id);
        }
    }
}
