using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalService.BL.Contracts;
using RentalService.BL.DTO;
using RentalService.Web.ViewModels;

namespace RentalService.Web.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService cityService;
        private readonly ICountryService countryService;

        public CityController(ICityService cityService, ICountryService countryService)
        {
            this.cityService = cityService;
            this.countryService = countryService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var cities = await cityService.GetAllCitiesAsync();

            return View(cities?.Adapt<IEnumerable<CityVM>>());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("City ID wasn't set");
            }

            try
            {
                var city = await cityService.GetCityAsync(id);

                return View(city.Adapt<CityVM>());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(int? countryId, string countryName)
        {
            if (countryId == null)
            {
                var countries = await countryService.GetAllCountriesAsync();
                ViewData["Countries"] = new SelectList(countries, "Id", "Name");
            }
            else
            {
                ViewData["CountryId"] = countryId;
                ViewData["CountryName"] = countryName;
            }

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Name, CountryId")] CityVM city)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await cityService.UpdateCityAsync(city.Adapt<CityDTO>());
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.Id))
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

            var countries = await countryService.GetAllCountriesAsync();
            ViewData["Countries"] = new SelectList(countries, "Id", "Name");

            return View(city);
        }

        [HttpGet]
        [Authorize]
        public ActionResult AutocompleteSearch(string term, string countryName)
        {
            var cities = cityService.FindCitiesAsync(term, countryName)
                .GetAwaiter()
                .GetResult()
                .Select(c => new { value = c.Name });

            return Json(cities);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest("City ID wasn't set");
            }

            try
            {
                var city = await cityService.GetCityAsync(id);

                var countries = await countryService.GetAllCountriesAsync();
                ViewData["Countries"] = new SelectList(countries, "Id", "Name");

                return View(city.Adapt<CityVM>());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit([Bind("Id, Name, CountryId")] CityVM city)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await cityService.UpdateCityAsync(city.Adapt<CityDTO>());
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.Id))
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

            var countries = await countryService.GetAllCountriesAsync();
            ViewData["Countries"] = new SelectList(countries, "Id", "Name");

            return View(city);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("City ID wasn't set");
            }

            try
            {
                var city = await cityService.GetCityAsync(id);

                return View(city.Adapt<CityVM>());
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
            await cityService.DeleteCityAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int id)
        {
            return cityService.CityExists(id);
        }
    }
}
