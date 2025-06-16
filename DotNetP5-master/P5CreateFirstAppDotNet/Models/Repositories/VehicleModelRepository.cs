using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly ApplicationDbContext _context;
        public VehicleModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<VehicleModel>> GetAllModelsAsync()
        {
            return await _context.VehicleModels.ToListAsync();
        }
        public async Task<VehicleModel> GetModelByIdAsync(int id)
        {
            return await _context.VehicleModels.FindAsync(id)
                ?? throw new KeyNotFoundException($"Model with ID {id} not found.");
        }
        public async Task AddModelAsync(VehicleModel model)
        {
            await _context.VehicleModels.AddAsync(model);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateModelAsync(VehicleModel model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteModelAsync(int id)
        {
            var model = await GetModelByIdAsync(id);
            _context.VehicleModels.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}