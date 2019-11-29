using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RentalService.BL.Contracts;
using RentalService.BL.DTO;
using RentalService.BL.DTO.Filters;
using RentalService.Web.ViewModels;
using RentalService.Web.ViewModels.Filters;

namespace RentalService.Web.Controllers
{
    public class RentalPointCarController : Controller
    {
        private readonly IRentalPointCarService pointCarService;
        private readonly ICarService carService;
        private readonly IReservationService reservationService;

        public RentalPointCarController(IRentalPointCarService pointCarService, ICarService carService, IReservationService reservationService)
        {
            this.pointCarService = pointCarService;
            this.carService = carService;
            this.reservationService = reservationService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index(RentalPointCarFilterVM filter)
        {
            var pointCars = await pointCarService.SearchAsync(filter.Adapt<RentalPointCarFilterDTO>());

            var model = new IndexRentalPointCarVM
            {
                Filter = filter,
                Cars = pointCars?.Adapt<IEnumerable<RentalPointCarVM>>()
            };

            return View(model);
        }

        [HttpGet]
        [Authorize]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(int pointId)
        {
            ViewData["RentalPointId"] = pointId;

            var cars = await carService.GetAllCarsAsync();
            ViewData["Cars"] = new SelectList(cars, "Id", "Name");

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await pointCarService.DeleteRentalPointCarAsync(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Reserve(int carId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var reservation = await reservationService.AddReservationAsync(User.Identity.Name, carId, startDate, endDate);

                TempData["reservation"] = JsonConvert.SerializeObject(reservation.Adapt<DetailedReservationVM>());

                return Json(new { redirectToUrl = Url.Action(nameof(ReserveDetails), "RentalPointCar") });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        public IActionResult ReserveDetails()
        {
            TempData.TryGetValue("reservation", out object reservation);

            return View(JsonConvert.DeserializeObject<DetailedReservationVM>((string)reservation));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ReserveDetails(DetailedReservationVM reservation)
        {
            await reservationService.SetTimeForKeyAsync(reservation.Id, reservation.KeyReceiptTime, reservation.KeyReturnTime);

            TempData["reservationId"] = reservation.Id;

            return RedirectToAction(nameof(ConfirmRental));
        }

        [Authorize]
        public async Task<IActionResult> ConfirmRental()
        {
            var reservation = await reservationService.GetReservationAsync((int)TempData["reservationId"]);

            return View(reservation.Adapt<DetailedReservationVM>());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ConfirmRental(DetailedReservationVM reservation)
        {
            await reservationService.ConfirmRentalAsync(reservation.Id, reservation.Cost);

            return RedirectToAction(nameof(Index));
        }

        private bool PointCarExists(int id)
        {
            return pointCarService.RentalPointCarExists(id);
        }
    }
}
