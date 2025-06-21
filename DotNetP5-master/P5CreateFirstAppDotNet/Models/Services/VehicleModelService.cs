using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.Repositories;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IVehicleModelRepository _vehicleModelRepository;
        private readonly IVehicleBrandService _vehicleBrandService;

        public VehicleModelService(IVehicleModelRepository vehicleModelRepository, IVehicleBrandService vehicleBrandService)
        {
            _vehicleModelRepository = vehicleModelRepository;
            _vehicleBrandService = vehicleBrandService;
        }

        public async Task<IEnumerable<VehicleModel>> GetAllVehicleModelsAsync()
        {
            return await _vehicleModelRepository.GetAllVehicleModelsAsync();
        }

        public async Task<VehicleModel?> GetVehicleModelByIdAsync(int modelId)
        {
            return await _vehicleModelRepository.GetVehicleModelByIdAsync(modelId);
        }
        public async Task<VehicleModel> AddNewModelAsync(string modelName, int brandId)
        {
            VehicleBrand? existingBrand = await _vehicleBrandService.GetVehicleBrandByIdAsync(brandId);
            if (existingBrand == null)
            {
                throw new InvalidOperationException("La marque spécifiée est introuvable.");
            }

            VehicleModel? existingModel = await _vehicleModelRepository.GetVehicleModelByNameAsync(modelName);
            if (existingModel != null)
            {
                throw new InvalidOperationException("Ce modèle existe déjà.");
            }

            VehicleModel newModel = new VehicleModel
            {
                Model = modelName,
                VehicleBrandId = brandId,
                VehicleBrand = existingBrand
            };

            await _vehicleModelRepository.AddVehicleModelAsync(newModel);

            return newModel;
        }
    }
}
