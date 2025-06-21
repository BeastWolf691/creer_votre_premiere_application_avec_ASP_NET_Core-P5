using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public interface IRepairService
    {
        Task AddRepairAsync(Repair repair);
        Task<Repair?> GetRepairByVehicleIdAsync(int vehicleId);
        Task UpdateRepairAsync(int vehicleId, VehicleViewModel vehicleViewModel);
    }
}
