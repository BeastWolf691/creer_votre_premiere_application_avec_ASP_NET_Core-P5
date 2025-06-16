using System.Linq;
using Microsoft.AspNetCore.Mvc;
using P5CreateFirstAppDotNet.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.Services;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;


        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vehicleViewModels = await _vehicleService.GetAllVehicleViewModelsAsync();
            if (vehicleViewModels == null || !vehicleViewModels.Any())
            {
                return View("Vehicles");
            }
            return View(vehicleViewModels.OrderByDescending(v => v.VehicleId));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await _vehicleService.GetVehicleViewModelAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleViewModel vehicleViewModel)
        {
            var newPath = await ProcessUploadedImageAsync(vehicleViewModel.ImageFile);
            if (!ModelState.IsValid)
            {
                return View(vehicleViewModel);
            }
            if (ModelState.IsValid)
            {
                vehicleViewModel.ImagePath = newPath;
                await _vehicleService.AddVehicleAsync(vehicleViewModel);
                return RedirectToAction("Index");
            }
            return View(vehicleViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VehicleViewModel vehicleViewModel)
        {
            var newPath = await ProcessUploadedImageAsync(vehicleViewModel.ImageFile, vehicleViewModel.ImagePath);
            if (!ModelState.IsValid)
            {
                return View(vehicleViewModel);
            }

            if (ModelState.IsValid)
            {
                vehicleViewModel.ImagePath = newPath;
                await _vehicleService.UpdateVehicleAsync(vehicleViewModel);
                return RedirectToAction("Index");
            }
            return View(vehicleViewModel);
        }

        private async Task<string?> ProcessUploadedImageAsync(IFormFile? imageFile, string? oldImagePath = null)
        {
            if (imageFile == null)
                return oldImagePath; // Aucun nouveau fichier : on garde l'ancien

            var allowedTypes = new[] { "image/jpeg", "image/png" };
            if (!allowedTypes.Contains(imageFile.ContentType))
            {
                ModelState.AddModelError("ImageFile", "Seuls les fichiers JPEG, PNG sont acceptés.");
                return null;
            }

            long maxFileSize = 2 * 1024 * 1024; // 2 Mo
            if (imageFile.Length > maxFileSize)
            {
                ModelState.AddModelError("ImageFile", "La taille du fichier ne doit pas dépasser 2 Mo.");
                return null;
            }

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/vehicles");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            // Supprimer l'ancien fichier (optionnel)
            if (!string.IsNullOrEmpty(oldImagePath))
            {
                var oldImagePhysicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", oldImagePath.TrimStart('/'));
                if (System.IO.File.Exists(oldImagePhysicalPath))
                {
                    System.IO.File.Delete(oldImagePhysicalPath);
                }
            }

            return "/images/vehicles/" + uniqueFileName;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _vehicleService.DeleteVehicleAsync(id);
            return RedirectToAction("Index");
        }
    }
}
