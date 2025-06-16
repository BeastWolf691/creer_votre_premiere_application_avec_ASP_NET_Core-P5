using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public interface IVehicleService
    {
 
        Task<List<VehicleViewModel>?> GetAllVehicleViewModelsAsync();
        Task<VehicleViewModel?> GetVehicleViewModelAsync(int id);
        Task AddVehicleAsync(VehicleViewModel vehicleViewModel);
        Task UpdateVehicleAsync(VehicleViewModel vehicleViewModel);
        VehicleViewModel MapToViewModel(Vehicle vehicle);

        Task DeleteVehicleAsync(int id);
    }
}