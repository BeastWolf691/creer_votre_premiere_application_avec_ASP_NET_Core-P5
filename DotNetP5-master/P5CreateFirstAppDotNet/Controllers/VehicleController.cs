using System.Linq;
using Microsoft.AspNetCore.Mvc;
using P5CreateFirstAppDotNet.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.Services;
using P5CreateFirstAppDotNet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace P5CreateFirstAppDotNet.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IVehicleModelRepository _vehicleModelRepository;
        private readonly ITrimRepository _trimRepository;
        private readonly IBrandRepository _brandRepository;


        public VehicleController(IVehicleRepository vehicleRepository, IStatusRepository statusRepository, IVehicleModelRepository vehicleModelRepository, ITrimRepository trimRepository, IBrandRepository brandRepository)
        {
            _vehicleRepository = vehicleRepository;
            _statusRepository = statusRepository;
            _vehicleModelRepository = vehicleModelRepository;
            _trimRepository = trimRepository;
            _brandRepository = brandRepository;
        }
        private async Task LoadSelectListsAsync(int? selectedBrandId = null, int? selectedModelId = null, int? selectedTrimId = null, int? selectedStatusId = null)
        {
            ViewBag.BrandList = new SelectList(await _brandRepository.GetAllBrandsAsync(), "BrandId", "Name", selectedBrandId);
            ViewBag.VehicleModelList = new SelectList(await _vehicleModelRepository.GetAllModelsAsync(), "VehicleModelId", "Name", selectedModelId);
            ViewBag.TrimList = new SelectList(await _trimRepository.GetAllTrimsAsync(), "TrimId", "Name", selectedTrimId);
            ViewBag.StatusList = new SelectList(await _statusRepository.GetAllStatusesAsync(), "StatusId", "Name", selectedStatusId);
        }

        private Vehicle MapViewModelToEntity(VehicleViewModel vm)
        {
            return new Vehicle
            {
                VehicleId = vm.VehicleId,
                VinCode = vm.VinCode,
                Year = vm.Year,
                PurchaseDate = vm.PurchaseDate,
                PurchasePrice = double.TryParse(vm.PurchasePrice, out var p) ? p : 0,
                Description = vm.Description,
                AvailableForSaleDate = vm.AvailableForSaleDate,
                SalePrice = double.TryParse(vm.SalePrice, out var s) ? s : 0,
                ImagePath = vm.ImagePath,
                VehicleModelId = vm.VehicleModelId,
                TrimId = vm.TrimId,
                StatusId = vm.StatusId
            };
        }

        private VehicleViewModel MapVehicleToViewModel(Vehicle vehicle)
        {
            return new VehicleViewModel
            {
                VehicleId = vehicle.VehicleId,
                VinCode = vehicle.VinCode,
                Year = vehicle.Year,
                PurchaseDate = vehicle.PurchaseDate,
                PurchasePrice = vehicle.PurchasePrice.ToString("0.00"),
                Description = vehicle.Description,
                AvailableForSaleDate = vehicle.AvailableForSaleDate,
                SalePrice = vehicle.SalePrice?.ToString("0.00"),
                SaleDate = vehicle.SaleDate,
                StatusId = vehicle.StatusId ?? 0,
                VehicleModelId = vehicle.VehicleModelId ?? 0,
                TrimId = vehicle.TrimId ?? 0,
                ImagePath = vehicle.ImagePath
            };
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vehicles = await _vehicleRepository.GetAllVehicleAsync();
            return View(vehicles.OrderByDescending(v => v.VehicleId));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadSelectListsAsync();
            return View(new VehicleViewModel());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
            if (
                vehicle == null) 
                return NotFound();

            var vm = MapVehicleToViewModel(vehicle);

            await LoadSelectListsAsync(null, vm.VehicleModelId, vm.TrimId, vm.StatusId);
            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = _vehicleRepository.GetVehicleByIdAsync(id.Value).Result;
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await LoadSelectListsAsync(vm.BrandId, vm.VehicleModelId, vm.TrimId, vm.StatusId);
                return View(vm);
            }

            vm.ImagePath = await ProcessUploadedImageAsync(vm.ImageFile);
            var vehicle = MapViewModelToEntity(vm);

            vehicle.CalculateSalePrice(); // Calculer le prix de vente basé sur les réparations et la marge bénéficiaire
            await _vehicleRepository.AddVehicleAsync(vehicle);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VehicleViewModel vm)
        {
            Console.WriteLine($"DEBUG: VehicleId reçu = {vm.VehicleId}");

            if (!ModelState.IsValid)
            {
                await LoadSelectListsAsync(vm.BrandId, vm.VehicleModelId, vm.TrimId, vm.StatusId);
                return View(vm);
            }

            vm.ImagePath = await ProcessUploadedImageAsync(vm.ImageFile, vm.ImagePath);
            var vehicle = MapViewModelToEntity(vm);

            vehicle.CalculateSalePrice(); // Calculer le prix de vente basé sur les réparations et la marge bénéficiaire
            await _vehicleRepository.UpdateVehicleAsync(vehicle);
            return RedirectToAction(nameof(Index));
        }

        private async Task<string?> ProcessUploadedImageAsync(IFormFile? imageFile, string? oldImagePath = null)
        {
            if (imageFile == null)
            {
                if (string.IsNullOrEmpty(oldImagePath))
                {
                    return "/images/vehicles/default.png";
                }
                return oldImagePath; // Aucun nouveau fichier : on garde l'ancien
            }

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
            if (!string.IsNullOrEmpty(oldImagePath) && !oldImagePath.Contains("default.png"))
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
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            await _vehicleRepository.DeleteVehicleAsync(id);
            return View("DeleteConfirmation", vehicle);
        }
    }
}
