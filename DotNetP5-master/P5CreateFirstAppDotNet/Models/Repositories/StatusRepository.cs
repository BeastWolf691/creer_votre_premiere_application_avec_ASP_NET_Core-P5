using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Data;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ApplicationDbContext _context;
        public StatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Status>> GetAllStatusesAsync()
        {
            return await _context.Statuses.ToListAsync();
        }
        public async Task<Status> GetStatusByIdAsync(int id)
        {
            return await _context.Statuses.FindAsync(id)
                ?? throw new KeyNotFoundException($"Status with ID {id} not found.");
        }
        public async Task AddStatusAsync(Status status)
        {
            await _context.Statuses.AddAsync(status);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateStatusAsync(Status status)
        {
            _context.Entry(status).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStatusAsync(int id)
        {
            var status = await GetStatusByIdAsync(id);
            _context.Statuses.Remove(status);
            await _context.SaveChangesAsync();
        }
    }
}
