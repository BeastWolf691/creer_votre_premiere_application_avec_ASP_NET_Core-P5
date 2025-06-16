using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.Repositories;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public class TrimService : ITrimService
    {
        private readonly ITrimRepository _trimRepository;
        public TrimService(ITrimRepository trimRepository)
        {
            _trimRepository = trimRepository;
        }
        public async Task<IEnumerable<TrimViewModel>> GetAllTrimsAsync()
        {
            var trims = await _trimRepository.GetAllTrimsAsync();
            return trims.Select(MapToViewModel);
        }

        public async Task<TrimViewModel> GetTrimByIdAsync(int id)
        {
            var trim = await _trimRepository.GetTrimByIdAsync(id);
            return MapToViewModel(trim);
        }

        public async Task AddTrimAsync(TrimViewModel trimViewModel)
        {
            var trim = MapToEntity(trimViewModel);
            await _trimRepository.AddTrimAsync(trim);
        }

        public async Task UpdateTrimAsync(TrimViewModel trimViewModel)
        {
            var trim = MapToEntity(trimViewModel);
            await _trimRepository.UpdateTrimAsync(trim);
        }

        public async Task DeleteTrimAsync(int id)
        {
            await _trimRepository.DeleteTrimAsync(id);
        }

        public TrimViewModel MapToViewModel(Trim trim)
        {
            return new TrimViewModel
            {
                TrimId = trim.TrimId,
                Name = trim.Name,
                VehicleModelId = trim.VehicleModelId
            };
        }

        private Trim MapToEntity(TrimViewModel trimViewModel)
        {
            return new Trim
            {
                TrimId = trimViewModel.TrimId,
                Name = trimViewModel.Name,
                VehicleModelId = trimViewModel.VehicleModelId
            };
        }

    }
}
