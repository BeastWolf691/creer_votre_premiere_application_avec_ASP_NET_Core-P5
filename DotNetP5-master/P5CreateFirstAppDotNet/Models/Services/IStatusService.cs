using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public interface IStatusService
    {

        Task<IEnumerable<StatusViewModel>> GetAllStatusesAsync();
        Task<StatusViewModel> GetStatusByIdAsync(int id);
        Task AddStatusAsync(StatusViewModel statusViewModel);
        Task UpdateStatusAsync(StatusViewModel statusViewModel);
        Task DeleteStatusAsync(int id);
        StatusViewModel MapToViewModel(Status status);
    }
}
