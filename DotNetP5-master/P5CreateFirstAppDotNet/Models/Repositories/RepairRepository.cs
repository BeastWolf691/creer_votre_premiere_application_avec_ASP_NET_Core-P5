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

        public async Task<Repair> GetRepairByIdAsync(int id)
        {
            return await _context.Repairs.FindAsync(id)
                ?? throw new KeyNotFoundException($"Repair with ID {id} not found.");
        }

        public async Task AddRepairAsync(Repair repair)
        {
            await _context.Repairs.AddAsync(repair);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRepairAsync(Repair repair)
        {
            _context.Entry(repair).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}