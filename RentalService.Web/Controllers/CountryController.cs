using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var countries = await service.GetAllCountriesAsync();

            return View(countries?.Adapt<IEnumerable<CountryVM>>());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Name, Code")] CountryVM country)
        {
            if (ModelState.IsValid)
            {
                await service.AddCountryAsync(country.Adapt<CountryDTO>());

                return RedirectToAction(nameof(Index));
            }

            return View(country);
        }

        [HttpGet]
        [Authorize]
        public ActionResult AutocompleteSearch(string term)
        {
            var countries = service.FindCountriesAsync(term)
                .GetAwaiter()
                .GetResult()
                .Select(c => new { value = c.Name });

            return Json(countries);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit([Bind("Id, Name, Code")] CountryVM country)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await service.UpdateCountryAsync(country.Adapt<CountryDTO>());
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await service.DeleteCountryAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private bool CountryExists(int id)
        {
            return service.CountryExists(id);
        }
    }
}
