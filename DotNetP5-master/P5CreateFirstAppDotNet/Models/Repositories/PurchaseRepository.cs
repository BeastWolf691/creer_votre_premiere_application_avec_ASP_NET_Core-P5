using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Data;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        public readonly ApplicationDbContext _context;

        public PurchaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchasesAsync()
        {
            return await _context.Purchases.ToListAsync();
        }

        public async Task<Purchase?> GetPurchaseByIdAsync(int purchaseId)
        {
            return await _context.Purchases.FirstOrDefaultAsync(p => p.Id == purchaseId);
        }
        public async Task<Purchase?> GetPurchaseByVehicleIdAsync(int vehicleId)
        {
            return await _context.Purchases.FirstOrDefaultAsync(p => p.VehicleId == vehicleId);
        }

        public async Task AddPurchaseAsync(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePurchaseAsync(Purchase purchase)
        {
            _context.Purchases.Update(purchase);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePurchaseAsync(int purchaseId)
        {
            Purchase? purchase = await _context.Purchases.FindAsync(purchaseId);
            if (purchase is not null)
            {
                _context.Purchases.Remove(purchase);
                await _context.SaveChangesAsync();
            }
        }
    }
}
