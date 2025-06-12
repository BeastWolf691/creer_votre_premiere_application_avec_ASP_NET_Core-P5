using P5CreateFirstAppDotNet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public interface IVehicleModelRepository
    {
        Task<IEnumerable<VehicleModel>> GetAllModelsAsync();
        Task<VehicleModel> GetModelByIdAsync(int id);
        Task AddModelAsync(VehicleModel vehicleModel);
        Task UpdateModelAsync(VehicleModel vehicleModel);
    }
}