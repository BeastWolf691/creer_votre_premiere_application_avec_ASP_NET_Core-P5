using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public interface IVehicleModelService
    {

        Task<IEnumerable<VehicleModelViewModel>> GetAllModelsAsync();
        Task<VehicleModelViewModel> GetModelByIdAsync(int id);
        Task AddModelAsync(VehicleModelViewModel vehicleModelViewModel);
        Task UpdateModelAsync(VehicleModelViewModel vehicleModelViewModel);
        Task DeleteModelAsync(int id);
        VehicleModelViewModel MapToViewModel(VehicleModel vehicleModel);
    }
}
