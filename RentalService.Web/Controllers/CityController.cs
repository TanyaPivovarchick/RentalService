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
        public async Task<IActionResult> Index()
        {
            var cities = await cityService.GetAllCitiesAsync();

            return View(cities?.Adapt<IEnumerable<CityVM>>());
        }

        [HttpGet]
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
        public async Task<IActionResult> Create()
        {
            var countries = await countryService.GetAllCountriesAsync();
            ViewData["Countries"] = new SelectList(countries, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, CountryId")] CityVM city)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await cityService.UpdateCity(city.Adapt<CityDTO>());
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
        public async Task<IActionResult> Edit([Bind("Id, Name, CountryId")] CityVM city)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await cityService.UpdateCity(city.Adapt<CityDTO>());
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await cityService.DeleteCity(id);

            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int id)
        {
            return cityService.CityExists(id);
        }
    }
}
