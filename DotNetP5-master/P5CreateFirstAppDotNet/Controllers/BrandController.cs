using System.Linq;
using Microsoft.AspNetCore.Mvc;
using P5CreateFirstAppDotNet.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandRepository _brandRepository;
        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var brands = await _brandRepository.GetAllBrandsAsync();
            return View(brands.OrderByDescending(b => b.BrandId));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View(new BrandViewModel());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var brand = _brandRepository.GetBrandByIdAsync(id).Result;
            if (brand == null)
            {
                return NotFound();
            }

            var model = new BrandViewModel
            {
                BrandId = brand.BrandId,
                Name = brand.Name
            };
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var brand = _brandRepository.GetBrandByIdAsync(id.Value).Result;
            if (brand == null)
            {
                return NotFound();
            }
            var model = new BrandViewModel
            {
                BrandId = brand.BrandId,
                Name = brand.Name
            };
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                var brand = new Brand
                {
                    Name = model.Name
                };
                await _brandRepository.AddBrandAsync(brand);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                var brand = await _brandRepository.GetBrandByIdAsync(model.BrandId);
                if (brand == null)
                {
                    return NotFound();
                }
                brand.Name = model.Name;

                await _brandRepository.UpdateBrandAsync(brand);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var brand = await _brandRepository.GetBrandByIdAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            await _brandRepository.DeleteBrandAsync(id);

            var model = new BrandViewModel
            {
                BrandId = brand.BrandId,
                Name = brand.Name
            };
            return View("DeleteConfirmation", model);
        }

    }
}