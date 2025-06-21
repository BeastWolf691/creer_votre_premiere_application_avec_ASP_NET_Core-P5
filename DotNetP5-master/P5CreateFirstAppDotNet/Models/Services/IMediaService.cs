using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public interface IMediaService
    {
        Task AddMediaToVehicleAsync(int vehicleId, Media media);
        Task ProcessMediaFilesAsync(int vehicleId, List<IFormFile> mediaFiles);
        Task UpdateMediaFilesAsync(int vehicleId, List<IFormFile> mediaFiles);
    }
}
