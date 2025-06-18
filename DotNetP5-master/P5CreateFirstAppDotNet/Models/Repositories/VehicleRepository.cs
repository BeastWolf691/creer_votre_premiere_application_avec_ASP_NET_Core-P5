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

        public async Task<IEnumerable<Vehicle>> GetAllVehicleAsync()
        {
            return await _context.Vehicles
                .Include(v => v.VehicleModel)
                    .ThenInclude(vm => vm.Brand)
                .Include(v => v.Trim)
                .Include(v => v.VehicleRepairs)
                .Include(v => v.Status)
                .ToListAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
            return await _context.Vehicles
                .Include(v => v.VehicleModel)
                .ThenInclude(vm => vm.Brand)
                .Include(v => v.Trim)
                .Include(v => v.VehicleRepairs)
                    .ThenInclude(vr => vr.Repair)
                .Include(v => v.Status)
                .FirstAsync(v => v.VehicleId == id);
        }

        public async Task AddVehicleAsync(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVehicleAsync(Vehicle vehicle)
        {
            var existingVehicle = await _context.Vehicles.FindAsync(vehicle.VehicleId);
            if (existingVehicle == null)
            {
                throw new KeyNotFoundException($"Le véhicule avec l'ID {vehicle.VehicleId} est introuvable.");
            }
            // Mise à jour manuelle des propriétés
            existingVehicle.VinCode = vehicle.VinCode;
            existingVehicle.Year = vehicle.Year;
            existingVehicle.PurchaseDate = vehicle.PurchaseDate;
            existingVehicle.PurchasePrice = vehicle.PurchasePrice;
            existingVehicle.Description = vehicle.Description;
            existingVehicle.AvailableForSaleDate = vehicle.AvailableForSaleDate;
            existingVehicle.SalePrice = vehicle.SalePrice;
            existingVehicle.ImagePath = vehicle.ImagePath;
            existingVehicle.VehicleModelId = vehicle.VehicleModelId;
            existingVehicle.TrimId = vehicle.TrimId;
            existingVehicle.StatusId = vehicle.StatusId;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateVehicleStatusAsync(int vehicleId, Status newStatus)
        {
            var vehicle = await _context.Vehicles.FindAsync(vehicleId)
                ?? throw new KeyNotFoundException($"Le véhicule avec l'ID {vehicleId} est introuvable.");

            vehicle.Status = newStatus;
            _context.Entry(vehicle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByStatusAsync(Status status)
        {
            return await _context.Vehicles
                .Where(v => v.StatusId == status.StatusId)
                .Include(v => v.VehicleModel)
                .ThenInclude(vm => vm.Brand)
                .Include(v => v.Trim)
                .Include(v => v.VehicleRepairs)
                .Include(v => v.Status)
                .ToListAsync();
        }

        public async Task DeleteVehicleAsync(int vehicleId)
        {
            var vehicle = await _context.Vehicles.FindAsync(vehicleId);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Le véhicule avec l'ID {vehicleId} est introuvable.");
            }

        }
    }
}