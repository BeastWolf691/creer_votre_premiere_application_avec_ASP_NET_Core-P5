using P5CreateFirstAppAspDotNet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5CreateFirstAppAspDotNet.Models.Repositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllVehicleAsync();
        Task<Vehicle> GetVehicleByIdAsync(int id);
        Task AddVehicleAsync(Vehicle vehicle);
        Task UpdateVehicleAsync(Vehicle vehicle);
        Task UpdateVehicleStatusAsync(int vehicleId, VehicleStatus newStatus);
        Task<IEnumerable<Vehicle>> GetVehiclesByStatusAsync(VehicleStatus status);

    }
}