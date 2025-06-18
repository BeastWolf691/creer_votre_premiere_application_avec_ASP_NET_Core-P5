using System.Linq;
using Microsoft.AspNetCore.Mvc;
using P5CreateFirstAppDotNet.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.Services;
using P5CreateFirstAppDotNet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using System.Text.RegularExpressions;

namespace P5CreateFirstAppDotNet.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IVehicleModelRepository _vehicleModelRepository;
        private readonly ITrimRepository _trimRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IVehicleService _vehicleService;


        public VehicleController(IVehicleRepository vehicleRepository, IStatusRepository statusRepository, IVehicleModelRepository vehicleModelRepository, ITrimRepository trimRepository, IBrandRepository brandRepository, IVehicleService vehicleService)
        {
            _vehicleRepository = vehicleRepository;
            _statusRepository = statusRepository;
            _vehicleModelRepository = vehicleModelRepository;
            _trimRepository = trimRepository;
            _brandRepository = brandRepository;
            _vehicleService = vehicleService;

        }
        private async Task LoadSelectListsAsync(int? selectedBrandId = null, int? selectedModelId = null, int? selectedTrimId = null, int? selectedStatusId = null)
        {
            ViewBag.BrandList = new SelectList(await _brandRepository.GetAllBrandsAsync(), "BrandId", "Name", selectedBrandId);
            ViewBag.VehicleModelList = new SelectList(await _vehicleModelRepository.GetAllModelsAsync(), "VehicleModelId", "Name", selectedModelId);
            ViewBag.TrimList = new SelectList(await _trimRepository.GetAllTrimsAsync(), "TrimId", "Name", selectedTrimId);
            ViewBag.StatusList = new SelectList(await _statusRepository.GetAllStatusesAsync(), "StatusId", "Name", selectedStatusId);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vehicles = await _vehicleService.GetAllVehicleViewModelsAsync();

            if (vehicles == null || !vehicles.Any())
            {
                return View("NoVehiclesFound");
            }

            return View(vehicles);
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
        public IActionResult SuccessAdd()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var vm = await _vehicleService.GetVehicleViewModelAsync(id);
            if (vm == null)
                return NotFound();

            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
            if (
                vehicle == null)
                return NotFound();

            var vm = _vehicleService.MapVehicleToViewModel(vehicle);

            await LoadSelectListsAsync(null, vm.VehicleModelId, vm.TrimId, vm.StatusId);
            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id.Value);
            if (vehicle == null)
                return NotFound();

            var viewModel = _vehicleService.MapVehicleToViewModel(vehicle);
            return View(viewModel);
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
            await _vehicleService.AddVehicleAsync(vm);

            return RedirectToAction("SuccessAdd");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VehicleViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                await LoadSelectListsAsync(vm.BrandId, vm.VehicleModelId, vm.TrimId, vm.StatusId);
                return View(vm);
            }

            vm.ImagePath = await ProcessUploadedImageAsync(vm.ImageFile, vm.ImagePath);
            await _vehicleService.UpdateVehicleAsync(vm);

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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            await _vehicleService.DeleteVehicleAsync(id);

            var viewModel = _vehicleService.MapVehicleToViewModel(vehicle);
            return View("DeleteConfirmation", viewModel);
        }
    }
}
