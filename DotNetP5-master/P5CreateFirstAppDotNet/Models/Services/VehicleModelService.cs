using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.Repositories;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IVehicleModelRepository _vehicleModelRepository;

        public VehicleModelService(IVehicleModelRepository vehicleModelRepository)
        {
            _vehicleModelRepository = vehicleModelRepository;
        }

        public async Task<IEnumerable<VehicleModelViewModel>> GetAllModelsAsync()
        {
            var models = await _vehicleModelRepository.GetAllModelsAsync();
            return models.Select(MapToViewModel);
        }

        public async Task<VehicleModelViewModel> GetModelByIdAsync(int id)
        {
            var model = await _vehicleModelRepository.GetModelByIdAsync(id);
            return MapToViewModel(model);
        }

        public async Task AddModelAsync(VehicleModelViewModel vehicleModelViewModel)
        {
            var vehicleModel = MapToEntity(vehicleModelViewModel);
            await _vehicleModelRepository.AddModelAsync(vehicleModel);
        }

        public async Task UpdateModelAsync(VehicleModelViewModel vehicleModelViewModel)
        {
            var vehicleModel = MapToEntity(vehicleModelViewModel);
            await _vehicleModelRepository.UpdateModelAsync(vehicleModel);
        }

        public async Task DeleteModelAsync(int id)
        {
            await _vehicleModelRepository.DeleteModelAsync(id);
        }

        public VehicleModelViewModel MapToViewModel(VehicleModel vehicleModel)
        {
            return new VehicleModelViewModel
            {
                VehicleModelId = vehicleModel.VehicleModelId,
                Name = vehicleModel.Name,
                BrandId = vehicleModel.BrandId,
            };
        }

        private VehicleModel MapToEntity(VehicleModelViewModel vehicleModelViewModel)
        {
            return new VehicleModel
            {
                VehicleModelId = vehicleModelViewModel.VehicleModelId,
                Name = vehicleModelViewModel.Name,
                BrandId = vehicleModelViewModel.BrandId,
            };
        }
    }
}
