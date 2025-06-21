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
        public async Task<IEnumerable<VehicleModel>> GetAllVehicleModelsAsync()
        {
            return await _context.VehicleModels.ToListAsync();
        }

        public async Task<VehicleModel?> GetVehicleModelByIdAsync(int vehicleModelId)
        {
            return await _context.VehicleModels.FirstOrDefaultAsync(c => c.Id == vehicleModelId);
        }

        public async Task<VehicleModel?> GetVehicleModelByNameAsync(string modelName)
        {
            return await _context.VehicleModels.FirstOrDefaultAsync(m => m.Model == modelName);
        }
        public async Task<IEnumerable<VehicleModel>> GetVehicleModelsByBrandIdAsync(int brandId)
        {
            return await _context.VehicleModels
                                 .Where(m => m.VehicleBrandId == brandId)
                                 .ToListAsync();
        }

        public async Task AddVehicleModelAsync(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Add(vehicleModel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVehicleModelAsync(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Update(vehicleModel);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteVehicleModelAsync(int vehicleModelId)
        {
            VehicleModel? vehicleModel = await _context.VehicleModels.FindAsync(vehicleModelId);
            if (vehicleModel is not null)
            {
                _context.VehicleModels.Remove(vehicleModel);
                await _context.SaveChangesAsync();
            }
        }
    }
}