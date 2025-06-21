using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.Repositories;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public class VehicleBrandService : IVehicleBrandService
    {
        private readonly IVehicleBrandRepository _vehicleBrandRepository;

        public VehicleBrandService(IVehicleBrandRepository vehicleBrandRepository)
        {
            _vehicleBrandRepository = vehicleBrandRepository;
        }

        public async Task<IEnumerable<VehicleBrand>> GetAllVehicleBrandsAsync()
        {
            return await _vehicleBrandRepository.GetAllVehicleBrandsAsync();
        }

        public async Task<VehicleBrand?> GetVehicleBrandByIdAsync(int brandId)
        {
            return await _vehicleBrandRepository.GetVehicleBrandByIdAsync(brandId);
        }

        public async Task<VehicleBrand?> AddNewBrandAsync(string brandName)
        {
            VehicleBrand? existingBrand = await _vehicleBrandRepository.GetVehicleBrandByNameAsync(brandName);
            if (existingBrand != null)
            {
                throw new InvalidOperationException("Cette marque existe déjà.");
            }

            VehicleBrand newBrand = new VehicleBrand { Brand = brandName };
            await _vehicleBrandRepository.AddVehicleBrandAsync(newBrand);

            return newBrand;
        }
    }
}
