using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public class VehicleTrimRepository : IVehicleTrimRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleTrimRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleTrim>> GetAllVehicleTrimsAsync()
        {
            return await _context.VehicleTrims.ToListAsync();
        }

        public async Task<VehicleTrim> GetVehicleTrimByIdAsync(int VehicleTrimId)
        {
            var result = await _context.VehicleTrims.FirstOrDefaultAsync(c => c.Id == VehicleTrimId);
            if (result is null)
                throw new InvalidOperationException($"Aucun VehicleTrim trouvé avec l'ID {VehicleTrimId}.");
            return result;
        }

        public async Task<VehicleTrim> GetVehicleTrimByNameAsync(string trimLabel)
        {
            var result = await _context.VehicleTrims.FirstOrDefaultAsync(c => c.TrimLabel == trimLabel);
            if (result is null)
                throw new InvalidOperationException($"Aucun VehicleTrim trouvé avec le nom {trimLabel}.");
            return result;
        }
        public async Task AddVehicleTrimAsync(VehicleTrim VehicleTrim)
        {
            _context.VehicleTrims.Add(VehicleTrim);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVehicleTrimAsync(VehicleTrim VehicleTrim)
        {
            _context.VehicleTrims.Update(VehicleTrim);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteVehicleTrimAsync(int VehicleTrimId)
        {
            VehicleTrim? vehicleTrim = await _context.VehicleTrims.FindAsync(VehicleTrimId);
            if (vehicleTrim is not null)
            {
                _context.VehicleTrims.Remove(vehicleTrim);
                await _context.SaveChangesAsync();
            }
        }
    }
}