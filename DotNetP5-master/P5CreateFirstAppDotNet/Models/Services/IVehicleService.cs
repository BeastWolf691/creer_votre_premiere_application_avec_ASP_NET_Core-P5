using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleViewModel>> GetAllVehiclesAsync();
        Task<VehicleViewModel> GetVehicleByIdAsync(int vehicleId);
        Task<IEnumerable<VehicleModel>> GetVehicleModelByBrandIdAsync(int brandId);

        Task<Vehicle> AddVehicleAsync(VehicleViewModel vehicleViewModel);
        Task UpdateVehicleAsync(int vehicleId, VehicleViewModel vehicleViewModel);
        Task DeleteVehicleAsync(int vehicleId);
        Task<bool> ValidateVehicleModelWithBrandAsync(int vehicleModelId, int vehicleBrandId);
        Task<IEnumerable<Media>> GetVehicleMediaAsync(int vehicleId);
        Task<bool> VehicleExistsAsync(int id);
    }
}
