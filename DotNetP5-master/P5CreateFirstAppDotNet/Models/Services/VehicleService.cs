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
        private readonly IStringLocalizer<VehicleService> _localizer;
        public VehicleService(IVehicleRepository vehicleRepository, IStringLocalizer<VehicleService> localizer)
        {
            _vehicleRepository = vehicleRepository;
            _localizer = localizer;
        }
        public Vehicle MapViewModelToEntity(VehicleViewModel vm)
        {
            return new Vehicle
            {
                VehicleId = vm.VehicleId,
                VinCode = vm.VinCode,
                Year = vm.Year,
                PurchaseDate = vm.PurchaseDate,
                PurchasePrice = double.TryParse(vm.PurchasePrice, NumberStyles.Any, CultureInfo.InvariantCulture, out var p) ? p : 0,
                Description = vm.Description,
                AvailableForSaleDate = vm.AvailableForSaleDate,
                SalePrice = double.TryParse(vm.SalePrice, NumberStyles.Any, CultureInfo.InvariantCulture, out var s) ? s : 0,
                ImagePath = vm.ImagePath,
                VehicleModelId = vm.VehicleModelId,
                TrimId = vm.TrimId,
                StatusId = vm.StatusId
            };
        }

        public VehicleViewModel MapVehicleToViewModel(Vehicle vehicle)
        {
            return new VehicleViewModel
            {
                VehicleId = vehicle.VehicleId,
                VinCode = vehicle.VinCode,
                Year = vehicle.Year,
                PurchaseDate = vehicle.PurchaseDate,
                Description = vehicle.Description,
                PurchasePrice = vehicle.PurchasePrice.ToString("0.00", CultureInfo.InvariantCulture),
                AvailableForSaleDate = vehicle.AvailableForSaleDate,
                SalePrice = vehicle.SalePrice?.ToString("F2"),
                SaleDate = vehicle.SaleDate,
                StatusId = vehicle.StatusId ?? 0,
                VehicleModelId = vehicle.VehicleModelId ?? 0,
                TrimId = vehicle.TrimId ?? 0,
                ImagePath = vehicle.ImagePath,
                BrandId = vehicle.VehicleModel?.Brand?.BrandId ?? 0,
                BrandName = vehicle.VehicleModel?.Brand?.Name,
                StatusName = vehicle.Status?.Name,
                VehicleModelName = vehicle.VehicleModel?.Name,
                TrimName = vehicle.Trim?.Name,
            };
        }

        public async Task<List<VehicleViewModel>?> GetAllVehicleViewModelsAsync()
        {
            var vehicleEntities = await _vehicleRepository.GetAllVehicleAsync();
            return vehicleEntities?.Select(MapVehicleToViewModel).ToList();
        }

        public async Task<VehicleViewModel?> GetVehicleViewModelAsync(int id)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
            return vehicle != null ? MapVehicleToViewModel(vehicle) : null;
        }

        public async Task AddVehicleAsync(VehicleViewModel vehicleViewModel)
        {
            var vehicle = MapViewModelToEntity(vehicleViewModel);
            await _vehicleRepository.AddVehicleAsync(vehicle);
        }

        public async Task AssignRepairsToVehicleAsync(int vehicleId, List<int> repairIds)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(vehicleId);
            if (vehicle == null)
                throw new ArgumentException("Véhicule non trouvé.");

            foreach (var repairId in repairIds)
            {
                bool alreadyAssigned = vehicle.VehicleRepairs.Any(vr => vr.RepairId == repairId);
                if (!alreadyAssigned)
                {
                    vehicle.VehicleRepairs.Add(new VehicleRepair
                    {
                        VehicleId = vehicleId,
                        RepairId = repairId
                    });
                }
            }

            // Recalcule le prix de vente
            vehicle.CalculateSalePrice();

            await _vehicleRepository.UpdateVehicleAsync(vehicle);
        }

        public async Task UpdateVehicleAsync(VehicleViewModel vehicleViewModel)
        {
            var vehicle = MapViewModelToEntity(vehicleViewModel);
            await _vehicleRepository.UpdateVehicleAsync(vehicle);
        }

        public async Task DeleteVehicleAsync(int id)
        {
            await _vehicleRepository.DeleteVehicleAsync(id);
        }
    }
}


