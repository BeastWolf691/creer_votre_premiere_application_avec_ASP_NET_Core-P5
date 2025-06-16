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

        public async Task<IEnumerable<RepairViewModel>> GetAllRepairsAsync()
        {
            var repairs = await _repairRepository.GetAllRepairsAsync();
            return repairs.Select(MapToViewModel);
        }

        public async Task<RepairViewModel> GetRepairByIdAsync(int id)
        {
            var repair = await _repairRepository.GetRepairByIdAsync(id);
            return MapToViewModel(repair);
        }

        public async Task AddRepairAsync(RepairViewModel repairViewModel)
        {
            var repair = MapToEntity(repairViewModel);
            await _repairRepository.AddRepairAsync(repair);

        }

        public async Task UpdateRepairAsync(RepairViewModel repairViewModel)
        {
            var repair = MapToEntity(repairViewModel);
            await _repairRepository.UpdateRepairAsync(repair);
        }

        public async Task DeleteRepairAsync(int id)
        {
            await _repairRepository.DeleteRepairAsync(id);
        }

        public RepairViewModel MapToViewModel(Repair repair)
        {
            return new RepairViewModel
            {
                RepairId = repair.RepairId,
                Name = repair.Name,
                RepairCost = repair.RepairCost.ToString(CultureInfo.InvariantCulture)
            };
        }

        private Repair MapToEntity(RepairViewModel repairViewModel)
        {
            return new Repair
            {
                RepairId = repairViewModel.RepairId,
                Name = repairViewModel.Name,
                RepairCost = double.Parse(repairViewModel.RepairCost, CultureInfo.InvariantCulture)
            };
        }
    }
}
