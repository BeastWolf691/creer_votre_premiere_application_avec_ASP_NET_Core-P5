using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles
                .Include(v => v.VehicleBrand)
                .Include(v => v.VehicleModel)
                .Include(v => v.VehicleTrim)
                .Include(v => v.YearOfProduction)
                .ToListAsync();
        }

        public async Task<Vehicle?> GetVehicleByIdAsync(int vehicleId)
        {
            return await _context.Vehicles
                .Include(v => v.VehicleBrand)
                .Include(v => v.VehicleModel)
                .Include(v => v.VehicleTrim)
                .Include(v => v.YearOfProduction)
                .FirstOrDefaultAsync(v => v.Id == vehicleId);
        }

        public async Task AddVehicleAsync(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVehicleAsync(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteVehicleAsync(int vehicleId)
        {
            Vehicle? vehicle = await _context.Vehicles.FindAsync(vehicleId);
            if (vehicle is not null)
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> VehicleExistsAsync(int id)
        {
            return await _context.Vehicles.AnyAsync(v => v.Id == id);
        }
    }
}