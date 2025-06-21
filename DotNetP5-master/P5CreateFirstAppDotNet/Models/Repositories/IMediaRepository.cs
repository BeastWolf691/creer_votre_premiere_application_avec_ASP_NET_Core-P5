using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public interface IMediaRepository
    {
        Task<IEnumerable<Media>> GetMediaByVehicleAsync(int vehicleId);
        Task AddMediaAsync(Media media);
        Task RemoveMediaAsync(int mediaId);
    }
}
