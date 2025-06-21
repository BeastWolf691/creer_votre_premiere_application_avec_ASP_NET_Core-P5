using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Data;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private readonly ApplicationDbContext _context;
        public MediaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Media>> GetMediaByVehicleAsync(int vehicleId)
        {
            return await _context.VehicleMedias
                .Where(vm => vm.VehicleId == vehicleId)
                .Include(vm => vm.Media)
                .Select(vm => vm.Media)
                .ToListAsync();
        }

        public async Task AddMediaAsync(Media media)
        {
            _context.Medias.Add(media);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveMediaAsync(int mediaId)
        {
            Media? media = await _context.Medias.FindAsync(mediaId);
            if (media is not null)
            {
                _context.Medias.Remove(media);
                await _context.SaveChangesAsync();
            }
        }
    }

}
