using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public class VehicleMediaRepository : IVehicleMediaRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleMediaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddVehicleMediaAsync(VehicleMedia vehicleMedia)
        {
            _context.VehicleMedias.Add(vehicleMedia);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<VehicleMedia>> GetVehicleMediasByVehicleIdAsync(int vehicleId)
        {
            return await _context.VehicleMedias
                .Where(vm => vm.VehicleId == vehicleId)
                .Include(vm => vm.Media)
                .ToListAsync();
        }

        public async Task RemoveVehicleMediaAsync(int vehicleId, int mediaId)
        {
            VehicleMedia? vehicleMedia = await _context.VehicleMedias
                .FirstOrDefaultAsync(vm => vm.VehicleId == vehicleId && vm.MediaId == mediaId);

            if (vehicleMedia is not null)
            {
                _context.VehicleMedias.Remove(vehicleMedia);
                await _context.SaveChangesAsync();
            }
        }
    }
}
