using P5CreateFirstAppDotNet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public interface IVehicleBrandRepository
    {
        Task<IEnumerable<VehicleBrand>> GetAllVehicleBrandsAsync();
        Task<VehicleBrand?> GetVehicleBrandByIdAsync(int vehicleBrandId);
        Task AddVehicleBrandAsync(VehicleBrand vehicleBrand);
        Task UpdateVehicleBrandAsync(VehicleBrand vehicleBrand);
        Task DeleteVehicleBrandAsync(int vehicleBrandId);
        Task<VehicleBrand?> GetVehicleBrandByNameAsync(string brandName);
    }
}