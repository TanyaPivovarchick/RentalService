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
    public class RentalPointCarController : Controller
    {
        private readonly IRentalPointCarService pointCarService;
        private readonly ICarService carService;

        public RentalPointCarController(IRentalPointCarService pointCarService, ICarService carService)
        {
            this.pointCarService = pointCarService;
            this.carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var pointCars = await pointCarService.GetAllRentalPointCarsAsync();

            return View(pointCars?.Adapt<IEnumerable<RentalPointCarVM>>());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("Rental point car ID wasn't set");
            }

            try
            {
                var pointCar = await pointCarService.GetRentalPointCarAsync(id);

                return View(pointCar.Adapt<RentalPointCarVM>());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create(int pointId)
        {
            ViewData["RentalPointId"] = pointId;

            var cars = await carService.GetAllCarsAsync();
            ViewData["Cars"] = new SelectList(cars, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RentalPointCarVM pointCar)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await pointCarService.UpdateRentalPointCarAsync(pointCar.Adapt<RentalPointCarDTO>());
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PointCarExists(pointCar.Id))
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

            var cars = await carService.GetAllCarsAsync();
            ViewData["Cars"] = new SelectList(cars, "Id", "Name");

            return View(pointCar);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest("Rental point car ID wasn't set");
            }

            try
            {
                var pointCar = await pointCarService.GetRentalPointCarAsync(id);

                var cars = await carService.GetAllCarsAsync();
                ViewData["Cars"] = new SelectList(cars, "Id", "Name");

                return View(pointCar.Adapt<RentalPointCarVM>());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RentalPointCarVM pointCar)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await pointCarService.UpdateRentalPointCarAsync(pointCar.Adapt<RentalPointCarDTO>());
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PointCarExists(pointCar.Id))
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

            var cars = await carService.GetAllCarsAsync();
            ViewData["Cars"] = new SelectList(cars, "Id", "Name");

            return View(pointCar);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Rental point car ID wasn't set");
            }

            try
            {
                var pointCar = await pointCarService.GetRentalPointCarAsync(id);

                return View(pointCar.Adapt<RentalPointCarVM>());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await pointCarService.DeleteRentalPointCarAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private bool PointCarExists(int id)
        {
            return pointCarService.RentalPointCarExists(id);
        }
    }
}
