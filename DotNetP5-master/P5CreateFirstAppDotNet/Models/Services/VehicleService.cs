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

        public async Task<List<VehicleViewModel>?> GetAllVehicleViewModelsAsync()
        {
            var vehicleEntities = await _vehicleRepository.GetAllVehicleAsync();
            return vehicleEntities?.Select(MapToViewModel).ToList();
        }

        public async Task<VehicleViewModel?> GetVehicleViewModelAsync(int id)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
            return vehicle != null ? MapToViewModel(vehicle) : null;
        }

        public async Task AddVehicleAsync(VehicleViewModel vehicleViewModel)
        {
            var vehicle = MapToEntity(vehicleViewModel);
            await _vehicleRepository.AddVehicleAsync(vehicle);
        }

        public async Task UpdateVehicleAsync(VehicleViewModel vehicleViewModel)
        {
            var vehicle = MapToEntity(vehicleViewModel);
            await _vehicleRepository.UpdateVehicleAsync(vehicle);
        }

        public VehicleViewModel MapToViewModel(Vehicle vehicle)
        {
            return new VehicleViewModel
            {
                VehicleId = vehicle.VehicleId,
                VinCode = vehicle.VinCode,
                Year = vehicle.Year,
                PurchaseDate = vehicle.PurchaseDate,
                PurchasePrice = vehicle.PurchasePrice.ToString(CultureInfo.InvariantCulture),
                Description = vehicle.Description,
                AvailableForSaleDate = vehicle.AvailableForSaleDate,
                SalePrice = vehicle.SalePrice?.ToString(CultureInfo.InvariantCulture),
                SaleDate = vehicle.SaleDate,
                ImageUrl = vehicle.ImageUrl,
                ImageThumbnailUrl = vehicle.ImageThumbnailUrl

            };
        }

        private Vehicle MapToEntity(VehicleViewModel vehicleViewModel)
        {
            return new Vehicle
            {
                VehicleId = vehicleViewModel.VehicleId,
                VinCode = vehicleViewModel.VinCode,
                Year = vehicleViewModel.Year,
                VehicleModelId = vehicleViewModel.VehicleModelId,
                TrimId = vehicleViewModel.TrimId,
                PurchaseDate = vehicleViewModel.PurchaseDate,
                PurchasePrice = double.Parse(vehicleViewModel.PurchasePrice, CultureInfo.InvariantCulture),
                Description = vehicleViewModel.Description,
                AvailableForSaleDate = vehicleViewModel.AvailableForSaleDate,
                SalePrice = string.IsNullOrEmpty(vehicleViewModel.SalePrice) ? null : double.Parse(vehicleViewModel.SalePrice, CultureInfo.InvariantCulture),
                SaleDate = vehicleViewModel.SaleDate,
                StatusId = vehicleViewModel.StatusId,
                ImageUrl = vehicleViewModel.ImageUrl,
                ImageThumbnailUrl = vehicleViewModel.ImageThumbnailUrl,
            };
        }
    }
}


