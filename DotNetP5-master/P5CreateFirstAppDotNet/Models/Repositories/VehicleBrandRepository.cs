using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public class VehicleBrandRepository : IVehicleBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public VehicleBrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleBrand>> GetAllVehicleBrandsAsync()
        {
            return await _context.VehicleBrands.ToListAsync();
        }

        public async Task<VehicleBrand?> GetVehicleBrandByIdAsync(int vehicleBrandId)
        {
            return await _context.VehicleBrands.FirstOrDefaultAsync(c => c.Id == vehicleBrandId);
        }
        public async Task AddVehicleBrandAsync(VehicleBrand vehicleBrand)
        {
            _context.VehicleBrands.Add(vehicleBrand);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateVehicleBrandAsync(VehicleBrand vehicleBrand)
        {
            _context.VehicleBrands.Update(vehicleBrand);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVehicleBrandAsync(int vehicleBrandId)
        {
            VehicleBrand? vehicleBrand = _context.VehicleBrands.Find(vehicleBrandId);
            if (vehicleBrand is not null)
            {
                _context.VehicleBrands.Remove(vehicleBrand);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<VehicleBrand?> GetVehicleBrandByNameAsync(string brandName)
        {
            return await _context.VehicleBrands.FirstOrDefaultAsync(b => b.Brand == brandName);
        }
    }
}