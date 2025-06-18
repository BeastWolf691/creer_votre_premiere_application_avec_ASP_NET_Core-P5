using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public interface IVehicleService
    {
 
        Task<List<VehicleViewModel>?> GetAllVehicleViewModelsAsync();
        Task<VehicleViewModel?> GetVehicleViewModelAsync(int id);
        Task AddVehicleAsync(VehicleViewModel vehicleViewModel);
        Task AssignRepairsToVehicleAsync(int vehicleId, List<int> repairIds);
        Task UpdateVehicleAsync(VehicleViewModel vehicleViewModel);
        VehicleViewModel MapVehicleToViewModel(Vehicle vehicle);
        Vehicle MapViewModelToEntity(VehicleViewModel vm);

        Task DeleteVehicleAsync(int id);
    }
}