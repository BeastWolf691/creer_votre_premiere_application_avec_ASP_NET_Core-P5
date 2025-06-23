using System.Globalization;
using Microsoft.Extensions.Localization;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.Repositories;
using P5CreateFirstAppDotNet.Models.ViewModels;
using System.Collections.Generic;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleModelRepository _vehicleModelRepository;
        private readonly IVehicleBrandRepository _vehicleBrandRepository;
        private readonly IVehicleTrimRepository _vehicleTrimRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ISaleService _saleService;
        private readonly IPurchaseService _purchaseService;
        private readonly IRepairService _repairService;


        public VehicleService(
            IVehicleRepository vehicleRepository,
            IVehicleModelRepository vehicleModelRepository,
            IVehicleBrandRepository vehicleBrandRepository,
            IVehicleTrimRepository vehicleTrimRepository,
            IMediaRepository mediaRepository,
            ISaleService saleService,
            IPurchaseService purchaseService,
            IRepairService repairService)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleModelRepository = vehicleModelRepository;
            _vehicleBrandRepository = vehicleBrandRepository;
            _vehicleTrimRepository = vehicleTrimRepository;
            _mediaRepository = mediaRepository;
            _saleService = saleService;
            _purchaseService = purchaseService;
            _repairService = repairService;
        }

        public async Task<IEnumerable<VehicleViewModel>> GetAllVehiclesAsync()
        {
            IEnumerable<Vehicle> vehicles = await _vehicleRepository.GetAllVehiclesAsync() ?? new List<Vehicle>();

            var vehicleViewModels = new List<VehicleViewModel>();

            foreach (var vehicle in vehicles)
            {

                var vehicleBrand = await _vehicleBrandRepository.GetVehicleBrandByIdAsync(vehicle.VehicleBrandId);
                var vehicleModel = await _vehicleModelRepository.GetVehicleModelByIdAsync(vehicle.VehicleModelId);

                VehicleTrim? vehicleTrim = null;
                if (vehicle.VehicleTrimId.HasValue)
                {
                    vehicleTrim = await _vehicleTrimRepository.GetVehicleTrimByIdAsync(vehicle.VehicleTrimId.Value);
                }

                var media = await GetVehicleMediaAsync(vehicle.Id);
                var firstMedia = media?.FirstOrDefault();

                Sale? sale = await _saleService.GetSaleByVehicleIdAsync(vehicle.Id);

                var vehicleViewModel = new VehicleViewModel
                {
                    Id = vehicle.Id,
                    Label = vehicle.Label,
                    VIN = vehicle.VIN,
                    Description = vehicle.Description ?? "Aucune description fournie",
                    VehicleBrandId = vehicle.VehicleBrand.Id,
                    VehicleModelId = vehicle.VehicleModel.Id,
                    VehicleTrimId = vehicle.VehicleTrim?.Id,
                    YearOfProduction = vehicle.YearOfProduction.Year,
                    Status = vehicle.Status,
                    BrandName = vehicleBrand?.Brand ?? "Marque inconnue",
                    ModelName = vehicleModel?.Model ?? "Modele inconnu",
                    TrimName = vehicleTrim?.TrimLabel ?? "Pas de finition",
                    MediaPath = firstMedia?.Path,
                    MediaLabel = firstMedia?.Label,
                    SaleDate = sale?.SaleDate,
                    SalePrice = sale?.SalePrice,
                    VehicleMedia = media?.Select(m => new VehicleMedia
                    {
                        MediaId = m.Id,
                        Media = m,
                        VehicleId = vehicle.Id,
                        Vehicle = vehicle
                    }).ToList()
                };

                vehicleViewModels.Add(vehicleViewModel);

            }

            return vehicleViewModels;
        }

        public async Task<VehicleViewModel> GetVehicleByIdAsync(int vehicleId)
        {
            Vehicle? vehicle = await _vehicleRepository.GetVehicleByIdAsync(vehicleId);

            if (vehicle?.VehicleBrandId == null)
                throw new Exception("VehicleBrandId est null");

            if (vehicle?.VehicleModelId == null)
                throw new Exception("VehicleModelId est null");

            var vehicleBrand = await _vehicleBrandRepository.GetVehicleBrandByIdAsync(vehicle.VehicleBrandId);
            var vehicleModel = await _vehicleModelRepository.GetVehicleModelByIdAsync(vehicle.VehicleModelId);

            VehicleTrim? vehicleTrim = null;
            if (vehicle.VehicleTrimId.HasValue)
            {
                vehicleTrim = await _vehicleTrimRepository.GetVehicleTrimByIdAsync(vehicle.VehicleTrimId.Value);
            }

            Sale? sale = await _saleService.GetSaleByVehicleIdAsync(vehicle.Id);
            Purchase? purchase = await _purchaseService.GetPurchaseByVehicleIdAsync(vehicle.Id);
            Repair? repair = await _repairService.GetRepairByVehicleIdAsync(vehicle.Id);

            var media = await GetVehicleMediaAsync(vehicle.Id);
            var firstMedia = media?.FirstOrDefault();

            return new VehicleViewModel
            {
                Id = vehicle.Id,
                Label = vehicle.Label,
                VIN = vehicle.VIN,
                Description = vehicle.Description ?? "Aucune description fournie",
                VehicleBrandId = vehicle.VehicleBrand.Id,
                VehicleModelId = vehicle.VehicleModel.Id,
                VehicleTrimId = vehicle.VehicleTrim?.Id,
                YearOfProduction = vehicle.YearOfProduction.Year,
                YearOfProductionId = vehicle.YearOfProduction.Id,
                Status = vehicle.Status,
                BrandName = vehicleBrand?.Brand ?? "Marque inconnue",
                ModelName = vehicleModel?.Model ?? "Modele inconnu",
                TrimName = vehicleTrim?.TrimLabel ?? "Pas de finition",
                MediaPath = firstMedia?.Path,
                MediaLabel = firstMedia?.Label,
                SaleDate = sale?.SaleDate,
                SalePrice = sale?.SalePrice,
                PurchaseDate = purchase?.PurchaseDate,
                PurchasePrice = purchase?.PurchasePrice,
                RepairDate = repair?.RepairDate,
                RepairCost = repair?.RepairCost,
                RepairDescription = repair?.Description
            };
        }
        public async Task<Vehicle> AddVehicleAsync(VehicleViewModel vehicleViewModel)
        {
            VehicleModel? carModel = await _vehicleModelRepository.GetVehicleModelByIdAsync(vehicleViewModel.VehicleModelId);

            Vehicle vehicle = new Vehicle
            {
                Label = vehicleViewModel.Label,
                VIN = vehicleViewModel.VIN,
                Description = vehicleViewModel.Description,
                YearOfProductionId = vehicleViewModel.YearOfProductionId,
                VehicleBrandId = vehicleViewModel.VehicleBrandId,
                VehicleModelId = vehicleViewModel.VehicleModelId,
                VehicleTrimId = vehicleViewModel.VehicleTrimId,
                Status = VehicleStatus.Maintenance
            };

            await _vehicleRepository.AddVehicleAsync(vehicle);
            return vehicle;
        }
        public async Task<IEnumerable<VehicleModel>> GetVehicleModelByBrandIdAsync(int brandId)
        {
            return await _vehicleModelRepository.GetVehicleModelsByBrandIdAsync(brandId);
        }

        public async Task UpdateVehicleAsync(int vehicleId, VehicleViewModel vehicleViewModel)
        {
            Vehicle? vehicle = await _vehicleRepository.GetVehicleByIdAsync(vehicleId);
            if (!await (ValidateVehicleModelWithBrandAsync(vehicleViewModel.VehicleModelId, vehicleViewModel.VehicleBrandId)))
            {
                throw new Exception("Le modèle sélectionné n'appartient pas à la marque choisie.");
            }
            if (vehicle == null)
            {
                throw new Exception($"Véhicule avec l'ID {vehicleId} non trouvé.");
            }

            vehicle.Label = vehicleViewModel.Label;
            vehicle.VIN = vehicleViewModel.VIN;
            vehicle.Description = vehicleViewModel.Description;
            vehicle.YearOfProductionId = vehicleViewModel.YearOfProductionId;
            vehicle.VehicleBrandId = vehicleViewModel.VehicleBrandId;
            vehicle.VehicleModelId = vehicleViewModel.VehicleModelId;
            vehicle.VehicleTrimId = vehicleViewModel.VehicleTrimId;
            vehicle.Status = vehicleViewModel.Status;

            await _vehicleRepository.UpdateVehicleAsync(vehicle);
        }

        public async Task DeleteVehicleAsync(int vehicleId)
        {
            await _vehicleRepository.DeleteVehicleAsync(vehicleId);
        }
        public async Task<bool> ValidateVehicleModelWithBrandAsync(int vehicleModelId, int vehicleBrandId)
        {
            VehicleModel vehicleModel = await _vehicleModelRepository.GetVehicleModelByIdAsync(vehicleModelId);
            if (vehicleModel is not null && vehicleModel.VehicleBrandId == vehicleBrandId) { return true; }
            return false;
        }

        public async Task<IEnumerable<Media>> GetVehicleMediaAsync(int vehicleId)
        {
            return await _mediaRepository.GetMediaByVehicleAsync(vehicleId);
        }

        public async Task<bool> VehicleExistsAsync(int id)
        {
            return await _vehicleRepository.VehicleExistsAsync(id);
        }
    }
}


