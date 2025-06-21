using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public interface IVehicleMediaRepository
    {
        Task AddVehicleMediaAsync(VehicleMedia vehicleMedia);
        Task<IEnumerable<VehicleMedia>> GetVehicleMediasByVehicleIdAsync(int vehicleId);
        Task RemoveVehicleMediaAsync(int vehicleId, int mediaId);
    }
}
