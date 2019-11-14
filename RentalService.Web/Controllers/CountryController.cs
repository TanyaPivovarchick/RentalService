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
    public class CountryController : Controller
    {
        private readonly ICountryService service;

        public CountryController(ICountryService countryService)
        {
            service = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var countries = await service.GetAllCountriesAsync();

            return View(countries?.Adapt<IEnumerable<CountryVM>>());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("Country ID wasn't set");
            }

            try
            {
                var country = await service.GetCountryAsync(id);

                return View(country.Adapt<CountryVM>());
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
        public async Task<IActionResult> Create([Bind("Name, Code")] CountryVM country)
        {
            if (ModelState.IsValid)
            {
                await service.AddCountry(country.Adapt<CountryDTO>());

                return RedirectToAction(nameof(Index));
            }

            return View(country);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest("Country ID wasn't set");
            }

            try
            {
                var country = await service.GetCountryAsync(id);

                return View(country.Adapt<CountryVM>());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id, Name, Code")] CountryVM country)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await service.UpdateCountry(country.Adapt<CountryDTO>());
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.Id))
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

            return View(country);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Country ID wasn't set");
            }

            try
            {
                var country = await service.GetCountryAsync(id);

                return View(country.Adapt<CountryVM>());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await service.DeleteCountry(id);

            return RedirectToAction(nameof(Index));
        }

        private bool CountryExists(int id)
        {
            return service.CountryExists(id);
        }
    }
}
