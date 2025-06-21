using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public interface IVehicleBrandService
    {
        Task<IEnumerable<VehicleBrand>> GetAllVehicleBrandsAsync();
        Task<VehicleBrand?> GetVehicleBrandByIdAsync(int brandId);
        Task<VehicleBrand?> AddNewBrandAsync(string brandName);
    }
}
