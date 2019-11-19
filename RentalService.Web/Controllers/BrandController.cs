using System.Collections.Generic;
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
    [Authorize(Roles = "Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandService service;

        public BrandController(IBrandService brandService)
        {
            service = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var brands = await service.GetAllBrandsAsync();

            return View(brands?.Adapt<IEnumerable<BrandVM>>());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("Brand ID wasn't set");
            }

            try
            {
                var brand = await service.GetBrandAsync(id);

                return View(brand.Adapt<BrandVM>());
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
        public async Task<IActionResult> Create([Bind("Name")] BrandVM brand)
        {
            if (ModelState.IsValid)
            {
                await service.AddBrandAsync(brand.Adapt<BrandDTO>());

                return RedirectToAction(nameof(Index));
            }

            return View(brand);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest("Brand ID wasn't set");
            }

            try
            {
                var brand = await service.GetBrandAsync(id);

                return View(brand.Adapt<BrandVM>());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id, Name")] BrandVM brand)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await service.UpdateBrandAsync(brand.Adapt<BrandDTO>());
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(brand.Id))
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

            return View(brand);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Brand ID wasn't set");
            }

            try
            {
                var brand = await service.GetBrandAsync(id);

                return View(brand.Adapt<BrandVM>());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await service.DeleteBrandAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private bool BrandExists(int id)
        {
            return service.BrandExists(id);
        }
    }
}
