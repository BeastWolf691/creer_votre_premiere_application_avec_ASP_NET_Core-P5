using System.Linq;
using Microsoft.AspNetCore.Mvc;
using P5CreateFirstAppDotNet.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using P5CreateFirstAppDotNet.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace P5CreateFirstAppDotNet.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly IVehicleModelRepository _modelRepository;
        private readonly IBrandRepository _brandRepository;

        public VehicleModelController(IVehicleModelRepository modelRepository, IBrandRepository brandRepository)
        {
            _modelRepository = modelRepository;
            _brandRepository = brandRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var models = await _modelRepository.GetAllModelsAsync();
            return View(models.OrderByDescending(m => m.VehicleModelId));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            var brands = _brandRepository.GetAllBrandsAsync().Result;
            ViewBag.BrandList = new SelectList(brands, "BrandId", "Name");
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _modelRepository.GetModelByIdAsync(id).Result;
            if (model == null)
            {
                return NotFound();
            }
            var brands = _brandRepository.GetAllBrandsAsync().Result;
            ViewBag.BrandList = new SelectList(brands, "BrandId", "Name", model.BrandId);
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
            var model = _modelRepository.GetModelByIdAsync(id.Value).Result;
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleModel model)
        {
            if (ModelState.IsValid)
            {
                await _modelRepository.AddModelAsync(model);
                return RedirectToAction("Index");
            }
            var brands = _brandRepository.GetAllBrandsAsync().Result;
            ViewBag.BrandList = new SelectList(brands, "BrandId", "Name", model.BrandId);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VehicleModel model)
        {
            if (ModelState.IsValid)
            {
                await _modelRepository.UpdateModelAsync(model);
                return RedirectToAction("Index");
            }
            var brands = _brandRepository.GetAllBrandsAsync().Result;
            ViewBag.BrandList = new SelectList(brands, "BrandId", "Name", model.BrandId);
            return View(model);

        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var model = await _modelRepository.GetModelByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            await _modelRepository.DeleteModelAsync(id);
            return View("DeleteConfirmation", model);
        }
    }
}
