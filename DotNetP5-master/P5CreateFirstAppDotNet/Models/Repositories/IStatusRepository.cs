using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public interface IStatusRepository
    {
        Task<IEnumerable<Status>> GetAllStatusesAsync();
        Task<Status> GetStatusByIdAsync(int id);
        Task AddStatusAsync(Status status);
        Task UpdateStatusAsync(Status status);
        Task DeleteStatusAsync(int id);
    }
}
