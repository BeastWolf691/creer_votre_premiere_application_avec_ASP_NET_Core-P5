using System.Linq;
using Microsoft.AspNetCore.Mvc;
using P5CreateFirstAppDotNet.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using P5CreateFirstAppDotNet.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace P5CreateFirstAppDotNet.Controllers
{
    public class TrimController : Controller
    {
        private readonly ITrimRepository _trimRepository;
        private readonly IVehicleModelRepository _vehicleModelRepository;

        public TrimController(ITrimRepository trimRepository, IVehicleModelRepository vehicleModelRepository)
        {
            _trimRepository = trimRepository;
            _vehicleModelRepository = vehicleModelRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var trims = await _trimRepository.GetAllTrimsAsync();
            return View(trims.OrderByDescending(t => t.TrimId));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var vehicleModels = _vehicleModelRepository.GetAllModelsAsync().Result;
            ViewBag.VehicleModelList = new SelectList(vehicleModels, "VehicleModelId", "Name");
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var model = _trimRepository.GetTrimByIdAsync(id).Result;
            if (model == null)
            {
                return NotFound();
            }
            var vehicleModels = _vehicleModelRepository.GetAllModelsAsync().Result;
            ViewBag.VehicleModelList = new SelectList(vehicleModels, "VehicleModelId", "Name", model.VehicleModelId);
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
            var model = _trimRepository.GetTrimByIdAsync(id.Value).Result;
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Trim model)
        {
            if (ModelState.IsValid)
            {
                await _trimRepository.AddTrimAsync(model);
                return RedirectToAction("Index");
            }
            var vehicleModels = await _vehicleModelRepository.GetAllModelsAsync();
            ViewBag.VehicleModelList = new SelectList(vehicleModels, "VehicleModelId", "Name", model.VehicleModelId);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Trim model)
        {
            if (ModelState.IsValid)
            {
                await _trimRepository.UpdateTrimAsync(model);
                return RedirectToAction("Index");
            }
            var vehicleModels = await _vehicleModelRepository.GetAllModelsAsync();
            ViewBag.VehicleModelList = new SelectList(vehicleModels, "VehicleModelId", "Name", model.VehicleModelId);
            return View(model);

        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _trimRepository.GetTrimByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            await _trimRepository.DeleteTrimAsync(id);
            return View("DeleteConfirmation", model);
        }
    }
}
