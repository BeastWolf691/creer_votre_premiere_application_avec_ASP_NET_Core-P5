using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public interface IRepairService
    {
        Task<IEnumerable<RepairViewModel>> GetAllRepairsAsync();
        Task<RepairViewModel> GetRepairByIdAsync(int id);
        Task AddRepairAsync(RepairViewModel repairViewModel);
        Task UpdateRepairAsync(RepairViewModel repairViewModel);
        Task DeleteRepairAsync(int id);
        RepairViewModel MapToViewModel(Repair repair);
    }
}
