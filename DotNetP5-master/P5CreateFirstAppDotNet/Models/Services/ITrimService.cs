using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public interface ITrimService
    {
        Task<IEnumerable<TrimViewModel>> GetAllTrimsAsync();
        Task<TrimViewModel> GetTrimByIdAsync(int id);
        Task AddTrimAsync(TrimViewModel trimViewModel);
        Task UpdateTrimAsync(TrimViewModel trimViewModel);
        Task DeleteTrimAsync(int id);
        TrimViewModel MapToViewModel(Trim trim);
    }
}
