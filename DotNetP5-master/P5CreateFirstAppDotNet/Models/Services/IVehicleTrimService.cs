using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public interface IVehicleTrimService
    {
        Task<IEnumerable<VehicleTrim>> GetAllVehicleTrimsAsync();
        Task<VehicleTrim> GetVehicleTrimByIdAsync(int trimId);
        Task<VehicleTrim> AddNewVehicleTrimAsync(string trimLabel);
    }
}
