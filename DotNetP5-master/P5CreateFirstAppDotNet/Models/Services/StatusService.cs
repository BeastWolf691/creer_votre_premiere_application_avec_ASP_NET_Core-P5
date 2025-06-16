using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.Repositories;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public async Task<IEnumerable<StatusViewModel>> GetAllStatusesAsync()
        {
            var statuses = await _statusRepository.GetAllStatusesAsync();
            return statuses.Select(MapToViewModel);
        }

        public async Task<StatusViewModel> GetStatusByIdAsync(int id)
        {
            var status = await _statusRepository.GetStatusByIdAsync(id);
            return MapToViewModel(status);
        }

        public async Task AddStatusAsync(StatusViewModel statusViewModel)
        {
            var status = MapToEntity(statusViewModel);
            await _statusRepository.AddStatusAsync(status);
        }

        public async Task UpdateStatusAsync(StatusViewModel statusViewModel)
        {
            var status = MapToEntity(statusViewModel);
            await _statusRepository.UpdateStatusAsync(status);
        }

        public async Task DeleteStatusAsync(int id)
        {
            await _statusRepository.DeleteStatusAsync(id);
        }

        public StatusViewModel MapToViewModel(Status status)
        {
            return new StatusViewModel
            {
                StatusId = status.StatusId,
                Name = status.Name
            };
        }

        private Status MapToEntity(StatusViewModel statusViewModel)
        {
            return new Status
            {
                StatusId = statusViewModel.StatusId,
                Name = statusViewModel.Name
            };
        }
    }
}
