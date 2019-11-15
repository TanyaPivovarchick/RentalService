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
    public class CarController : Controller
    {
        private readonly ICarService carService;
        private readonly IBrandService brandService;

        public CarController(ICarService carService, IBrandService brandService)
        {
            this.carService = carService;
            this.brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cars = await carService.GetAllCarsAsync();

            return View(cars?.Adapt<IEnumerable<CarVM>>());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("Car ID wasn't set");
            }

            try
            {
                var car = await carService.GetCarAsync(id);

                return View(car.Adapt<CarVM>());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var brands = await brandService.GetAllBrandsAsync();
            ViewData["Brands"] = new SelectList(brands, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, SeatCount, FuelConsumption, BrandId")] CarVM car)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await carService.UpdateCarAsync(car.Adapt<CarDTO>());
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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

            var brands = await brandService.GetAllBrandsAsync();
            ViewData["Brands"] = new SelectList(brands, "Id", "Name");

            return View(brands);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest("Car ID wasn't set");
            }

            try
            {
                var car = await carService.GetCarAsync(id);

                var brands = await brandService.GetAllBrandsAsync();
                ViewData["Brands"] = new SelectList(brands, "Id", "Name");

                return View(car.Adapt<CarVM>());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, SeatCount, FuelConsumption, BrandId")] CarVM car)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await carService.UpdateCarAsync(car.Adapt<CarDTO>());
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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

            var brands = await brandService.GetAllBrandsAsync();
            ViewData["Brands"] = new SelectList(brands, "Id", "Name");

            return View(car);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Car ID wasn't set");
            }

            try
            {
                var car = await carService.GetCarAsync(id);

                return View(car.Adapt<CarVM>());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await carService.DeleteCarAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return carService.CarExists(id);
        }
    }
}
