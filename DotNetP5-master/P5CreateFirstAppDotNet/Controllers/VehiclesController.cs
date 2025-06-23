using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.Services;
using P5CreateFirstAppDotNet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace P5CreateFirstAppDotNet.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IPurchaseService _purchaseService;
        private readonly IRepairService _repairService;
        private readonly ISaleService _saleService;
        private readonly IMediaService _mediaService;
        private readonly IVehicleTrimService _vehicleTrimService;
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IVehicleBrandService _vehicleBrandService;
        private readonly IYearOfProductionService _yearOfProductionService;
        private readonly ILogger<VehiclesController> _logger;

        public VehiclesController(IVehicleService vehicleService,
                              IPurchaseService purchaseService,
                              IRepairService repairService,
                              ISaleService saleService,
                              IMediaService mediaService,
                              IVehicleTrimService vehicleTrimService,
                              IVehicleModelService vehicleModelService,
                              IVehicleBrandService vehicleBrandService,
                              IYearOfProductionService yearOfProductionService,
                              ILogger<VehiclesController> logger)
        {
            _vehicleService = vehicleService;
            _purchaseService = purchaseService;
            _repairService = repairService;
            _saleService = saleService;
            _mediaService = mediaService;
            _vehicleTrimService = vehicleTrimService;
            _vehicleModelService = vehicleModelService;
            _vehicleBrandService = vehicleBrandService;
            _yearOfProductionService = yearOfProductionService;
            _logger = logger;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            var vehicle = await _vehicleService.GetAllVehiclesAsync();

            return View(vehicle);
        }

        // GET: Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            VehicleViewModel vehicle = await _vehicleService.GetVehicleByIdAsync(id.Value);
            if (vehicle is null)
            {
                return NotFound();
            }

            var media = await _vehicleService.GetVehicleMediaAsync(vehicle.Id);
            if (media is not null && media.Any())
            {
                var firstMedia = media.FirstOrDefault();
                vehicle.MediaPath = firstMedia.Path;
                vehicle.MediaLabel = firstMedia?.Label;
            }

            return View(vehicle);
        }

        // GET: Create
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            VehicleViewModel viewModel = new VehicleViewModel();

            viewModel = await PopulateViewModelSelectListsAsync(viewModel);

            return View(viewModel);
        }

        // POST: Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label,VIN,Description,YearOfProductionId,VehicleBrandId,VehicleModelId,VehicleTrimId,Status,PurchaseDate,PurchasePrice,MediaFiles")] VehicleViewModel vehicleViewModel)
        {
            // Validation métier : modèle appartient à la marque
            bool isModelValid = await _vehicleService.ValidateVehicleModelWithBrandAsync(vehicleViewModel.VehicleModelId, vehicleViewModel.VehicleBrandId);
            if (!isModelValid)
            {
                ModelState.AddModelError("VehicleModelId", "Le modèle sélectionné n'appartient pas à la marque choisie.");
            }

            // Validation métier : au moins une image
            if (vehicleViewModel.MediaFiles == null || vehicleViewModel.MediaFiles.Count == 0)
            {
                ModelState.AddModelError("MediaFiles", "Une image est requise pour la création du véhicule.");
            }

            // Vérification finale : s’il y a des erreurs de modèle ou de validation métier
            if (!ModelState.IsValid)
            {
                // Logging optionnel
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogError("Erreurs dans CREATE/POST : " + error.ErrorMessage);
                }

                // Réinitialisation des listes déroulantes
                vehicleViewModel = await PopulateViewModelSelectListsAsync(vehicleViewModel);
                return View(vehicleViewModel);
            }

            // Création du véhicule
            Vehicle vehicle = await _vehicleService.AddVehicleAsync(vehicleViewModel);

            // Création de l'achat
            Purchase purchase = new Purchase
            {
                VehicleId = vehicle.Id,
                PurchaseDate = vehicleViewModel.PurchaseDate ?? DateTime.Now,
                PurchasePrice = vehicleViewModel.PurchasePrice ?? 0
            };
            await _purchaseService.AddPurchaseAsync(purchase);

            // Traitement des médias
            try
            {
                await _mediaService.ProcessMediaFilesAsync(vehicle.Id, vehicleViewModel.MediaFiles);
                return View("CreateConfirmation");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("MediaFiles", ex.Message);
                vehicleViewModel = await PopulateViewModelSelectListsAsync(vehicleViewModel);
                return View(vehicleViewModel);
            }
        }

        // GET: Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            VehicleViewModel vehicle = await _vehicleService.GetVehicleByIdAsync(id.Value);
            var media = await _vehicleService.GetVehicleMediaAsync(vehicle.Id);
            if (media is not null && media.Any())
            {
                var firstMedia = media.FirstOrDefault();
                vehicle.MediaPath = firstMedia?.Path;
                vehicle.MediaLabel = firstMedia?.Label;
            }
            vehicle.PurchaseDate = (await _purchaseService.GetPurchaseByVehicleIdAsync(id.Value))?.PurchaseDate;
            vehicle.PurchasePrice = (await _purchaseService.GetPurchaseByVehicleIdAsync(id.Value))?.PurchasePrice;
            vehicle.RepairDate = (await _repairService.GetRepairByVehicleIdAsync(id.Value))?.RepairDate;
            vehicle.RepairCost = (await _repairService.GetRepairByVehicleIdAsync(id.Value))?.RepairCost;
            vehicle.RepairDescription = (await _repairService.GetRepairByVehicleIdAsync(id.Value))?.Description;
            vehicle.SalePrice = (await _saleService.GetSaleByVehicleIdAsync(id.Value))?.SalePrice;
            vehicle.SaleDate = (await _saleService.GetSaleByVehicleIdAsync(id.Value))?.SaleDate;

            if (vehicle is null)
            {
                return NotFound();
            }

            vehicle = await PopulateViewModelSelectListsAsync(vehicle);
            return View(vehicle);
        }

        // POST: Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label,VIN,Description,YearOfProductionId,VehicleBrandId,VehicleModelId,VehicleTrimId,Status,PurchaseDate,PurchasePrice,RepairDescription, RepairDate, RepairCost, SaleDate, SalePrice, MediaFiles")] VehicleViewModel vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogError("Erreurs dans EDIT/POST : " + error.ErrorMessage);
                }
                return View(vehicle);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _vehicleService.UpdateVehicleAsync(id, vehicle);
                    await _purchaseService.UpdatePurchaseAsync(id, vehicle);
                    if (vehicle.RepairCost is not null && vehicle.RepairDate is not null)
                    {
                        Repair repair = new Repair
                        {
                            VehicleId = vehicle.Id,
                            RepairDate = vehicle.RepairDate ?? DateTime.Now,
                            RepairCost = vehicle.RepairCost ?? 0,
                            Description = vehicle.RepairDescription ?? string.Empty
                        };
                        await _repairService.UpdateRepairAsync(id, vehicle);
                        vehicle.Status = VehicleStatus.Disponible;
                        await _vehicleService.UpdateVehicleAsync(id, vehicle);
                    }
                    if (vehicle.SalePrice is not null && vehicle.SaleDate is not null)
                    {
                        Sale sale = new Sale
                        {
                            VehicleId = vehicle.Id,
                            SaleDate = vehicle.SaleDate ?? DateTime.Now,
                            SalePrice = vehicle.SalePrice ?? 0
                        };
                        await _saleService.UpdateSaleAsync(id, vehicle);
                        vehicle.Status = VehicleStatus.Vendu;
                        await _vehicleService.UpdateVehicleAsync(id, vehicle);
                    }
                    try
                    {
                        if (vehicle.MediaFiles != null && vehicle.MediaFiles.Count > 0)
                        {
                            await _mediaService.UpdateMediaFilesAsync(vehicle.Id, vehicle.MediaFiles);
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        ModelState.AddModelError("MediaFiles", ex.Message);
                        return View(vehicle);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _vehicleService.VehicleExistsAsync(vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return View("EditConfirmation", vehicle);
            }

            vehicle = await PopulateViewModelSelectListsAsync(vehicle);

            return View(vehicle);
        }

        // GET: Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            VehicleViewModel vehicle = await _vehicleService.GetVehicleByIdAsync(id.Value);
            if (vehicle is null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
                await _vehicleService.DeleteVehicleAsync(id);
                return View("DeleteConfirmation", vehicle);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<JsonResult> GetVehicleModelsByBrand(int brandId)
        {
            var vehicleModels = await _vehicleService.GetVehicleModelByBrandIdAsync(brandId);
            var result = vehicleModels.Select(vehicle => new { vehicle.Id, vehicle.Model }).ToList();
            return Json(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddBrand(string brandName)
        {
            if (string.IsNullOrEmpty(brandName))
            {
                return Json(new { success = false });
            }

            try
            {
                var newBrand = await _vehicleBrandService.AddNewBrandAsync(brandName);
                return Json(new { success = true, brand = new { Id = newBrand?.Id, Brand = newBrand?.Brand } });
            }
            catch (InvalidOperationException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddModel(string modelName, int brandId)
        {
            if (string.IsNullOrEmpty(modelName) || brandId <= 0)
            {
                return Json(new { success = false });
            }

            try
            {
                var newModel = await _vehicleModelService.AddNewModelAsync(modelName, brandId);
                return Json(new { success = true, model = new { Id = newModel.Id, Model = newModel.Model, BrandId = newModel.VehicleBrandId } });
            }
            catch (InvalidOperationException ex)
            {
                return Json(new { sucess = false, message = ex.Message });
            }
        }

        private async Task<VehicleViewModel> PopulateViewModelSelectListsAsync(VehicleViewModel? viewModel = null)
        {
            viewModel ??= new VehicleViewModel();

            var brands = await _vehicleBrandService.GetAllVehicleBrandsAsync();
            var models = await _vehicleModelService.GetAllVehicleModelsAsync();
            var trims = await _vehicleTrimService.GetAllVehicleTrimsAsync();
            var years = await _yearOfProductionService.GetAllYearsOfProductionAsync();

            viewModel.VehicleBrands = new SelectList(brands, "Id", "Brand", viewModel.VehicleBrandId);
            viewModel.VehicleModels = new SelectList(models, "Id", "Model", viewModel.VehicleModelId);
            viewModel.VehicleTrims = new SelectList(trims, "Id", "TrimLabel", viewModel.VehicleTrimId);
            viewModel.YearsOfProduction = new SelectList(years, "Id", "Year", viewModel.YearOfProductionId);

            return viewModel;
        }

    }
}
