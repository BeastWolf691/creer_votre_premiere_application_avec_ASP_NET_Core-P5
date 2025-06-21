using P5CreateFirstAppDotNet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public interface IVehicleTrimRepository
    {
        Task<IEnumerable<VehicleTrim>> GetAllVehicleTrimsAsync();
        Task<VehicleTrim> GetVehicleTrimByIdAsync(int VehicleTrimId);
        Task<VehicleTrim> GetVehicleTrimByNameAsync(string trimLabel);
        Task AddVehicleTrimAsync(VehicleTrim VehicleTrim);
        Task UpdateVehicleTrimAsync(VehicleTrim VehicleTrim);
        Task DeleteVehicleTrimAsync(int VehicleTrimId);
    }
}