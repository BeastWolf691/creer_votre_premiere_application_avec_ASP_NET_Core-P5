using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public class RepairRepository : IRepairRepository
    {
        private readonly ApplicationDbContext _context;

        public RepairRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Repair>> GetAllRepairsAsync()
        {
            return await _context.Repairs.ToListAsync();
        }

        public async Task<Repair?> GetRepairByIdAsync(int RepairId)
        {
            return await _context.Repairs.FirstOrDefaultAsync(p => p.Id == RepairId);
        }

        public async Task<Repair?> GetRepairByVehicleIdAsync(int vehicleId)
        {
            return await _context.Repairs.FirstOrDefaultAsync(p => p.VehicleId == vehicleId);
        }

        public async Task AddRepairAsync(Repair Repair)
        {
            _context.Repairs.Add(Repair);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRepairAsync(Repair Repair)
        {
            _context.Repairs.Update(Repair);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRepairAsync(int RepairId)
        {
            Repair? repair = await _context.Repairs.FindAsync(RepairId);
            if (repair is not null)
            {
                _context.Repairs.Remove(repair);
                await _context.SaveChangesAsync();
            }
        }
    }
}