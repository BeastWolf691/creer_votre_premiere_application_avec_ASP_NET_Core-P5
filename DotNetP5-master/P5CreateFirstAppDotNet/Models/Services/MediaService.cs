using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.Repositories;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IVehicleMediaRepository _vehicleMediaRepository;

        public MediaService(IMediaRepository mediaRepository, IVehicleMediaRepository vehicleMediaRepository)
        {
            _mediaRepository = mediaRepository;
            _vehicleMediaRepository = vehicleMediaRepository;
        }

        public async Task AddMediaToVehicleAsync(int vehicleId, Media media)
        {
            await _mediaRepository.AddMediaAsync(media);

            VehicleMedia vehicleMedia = new VehicleMedia
            {
                VehicleId = vehicleId,
                MediaId = media.Id
            };

            await _vehicleMediaRepository.AddVehicleMediaAsync(vehicleMedia);
        }

        public async Task ProcessMediaFilesAsync(int vehicleId, List<IFormFile> mediaFiles)
        {
            foreach (IFormFile file in mediaFiles)
            {
                if (file.ContentType != "image/jpeg" && file.ContentType != "image/png")
                {
                    throw new InvalidOperationException("Les fichiers doivent être de type image (jpeg ou png).");
                }

                if (file.Length > 0)
                {
                    string filePath = Path.Combine("wwwroot/images/vehicles", file.FileName);

                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    Media media = new Media
                    {
                        Path = "/images/vehicles/" + file.FileName,
                        Label = Path.GetFileNameWithoutExtension(file.FileName),
                        TypeOfMediaId = 1 // Supposant qu'il s'agit d'une image
                    };

                    await AddMediaToVehicleAsync(vehicleId, media);
                }
            }
        }

        public async Task UpdateMediaFilesAsync(int vehicleId, List<IFormFile> mediaFiles)
        {
            var existingMedias = await _vehicleMediaRepository.GetVehicleMediasByVehicleIdAsync(vehicleId);
            foreach (var vehicleMedia in existingMedias)
            {
                await _vehicleMediaRepository.RemoveVehicleMediaAsync(vehicleMedia.VehicleId, vehicleMedia.MediaId);
                await _mediaRepository.RemoveMediaAsync(vehicleMedia.MediaId);
            }

            if (mediaFiles != null && mediaFiles.Count > 0)
            {
                await ProcessMediaFilesAsync(vehicleId, mediaFiles);
            }
        }
    }
}
