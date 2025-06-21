using System.Globalization;
using Microsoft.Extensions.Localization;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.Repositories;
using P5CreateFirstAppDotNet.Models.ViewModels;
using System.Collections.Generic;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public class RepairService : IRepairService
    {
        private readonly IRepairRepository _repairRepository;

        public RepairService(IRepairRepository repairRepository)
        {
            _repairRepository = repairRepository;
        }

        public async Task<Repair?> GetRepairByVehicleIdAsync(int vehicleId)
        {
            return await _repairRepository.GetRepairByVehicleIdAsync(vehicleId);
        }

        public async Task AddRepairAsync(Repair repair)
        {
            await _repairRepository.AddRepairAsync(repair);
        }

        public async Task UpdateRepairAsync(int vehicleId, VehicleViewModel vehicleViewModel)
        {
            Repair? repair = await GetRepairByVehicleIdAsync(vehicleId);
            if (repair is null)
            {
                repair = new Repair
                {
                    VehicleId = vehicleId,
                    Description = vehicleViewModel.RepairDescription ?? string.Empty,
                    RepairDate = vehicleViewModel.RepairDate ?? DateTime.Now,
                    RepairCost = vehicleViewModel.RepairCost ?? 0
                };
                await _repairRepository.AddRepairAsync(repair);
                return;
            }
            if (!string.IsNullOrWhiteSpace(vehicleViewModel.RepairDescription))
                repair.Description = vehicleViewModel.RepairDescription;

            if (vehicleViewModel.RepairDate.HasValue)
                repair.RepairDate = vehicleViewModel.RepairDate.Value;

            if (vehicleViewModel.RepairCost.HasValue)
                repair.RepairCost = vehicleViewModel.RepairCost.Value;

            await _repairRepository.UpdateRepairAsync(repair);
        }
    }
}
