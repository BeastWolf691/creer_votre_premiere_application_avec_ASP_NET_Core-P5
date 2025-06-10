using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly ApplicationDbContext _context;
        public ModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Model>> GetAllModelsAsync()
        {
            return await _context.Models.ToListAsync();
        }
        public async Task<Model> GetModelByIdAsync(int id)
        {
            return await _context.Models.FindAsync(id)
                ?? throw new KeyNotFoundException($"Model with ID {id} not found.");
        }
        public async Task AddModelAsync(Model model)
        {
            await _context.Models.AddAsync(model);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateModelAsync(Model model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}