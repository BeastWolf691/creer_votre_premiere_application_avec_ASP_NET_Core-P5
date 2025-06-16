using P5CreateFirstAppDotNet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllVehicleAsync();
        Task<Vehicle> GetVehicleByIdAsync(int id);
        Task AddVehicleAsync(Vehicle vehicle);
        Task UpdateVehicleAsync(Vehicle vehicle);
        Task UpdateVehicleStatusAsync(int vehicleId, Status newStatus);
        Task<IEnumerable<Vehicle>> GetVehiclesByStatusAsync(Status status);
        Task DeleteVehicleAsync(int id);
    }
}