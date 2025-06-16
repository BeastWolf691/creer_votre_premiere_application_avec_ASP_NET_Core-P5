using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public class TrimRepository : ITrimRepository
    {
        private readonly ApplicationDbContext _context;

        public TrimRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trim>> GetAllTrimsAsync()
        {
            return await _context.Trims.ToListAsync();
        }

        public async Task<Trim> GetTrimByIdAsync(int id)
        {
            return await _context.Trims.FindAsync(id)
                ?? throw new KeyNotFoundException($"Trim with ID {id} not found.");
        }
        public async Task AddTrimAsync(Trim trim)
        {
            await _context.Trims.AddAsync(trim);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTrimAsync(Trim trim)
        {
            _context.Entry(trim).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTrimAsync(int id)
        {
            var trim = await GetTrimByIdAsync(id);
            _context.Trims.Remove(trim);
            await _context.SaveChangesAsync();

        }
    }
}