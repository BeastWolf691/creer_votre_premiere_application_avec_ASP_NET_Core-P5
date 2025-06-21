using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Data;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        public readonly ApplicationDbContext _context;

        public SaleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sale>> GetAllSalesAsync()
        {
            return await _context.Sales.ToListAsync();
        }

        public async Task<Sale?> GetSaleByIdAsync(int SaleId)
        {
            return await _context.Sales.FirstOrDefaultAsync(p => p.Id == SaleId);
        }

        public async Task<Sale?> GetSaleByVehicleIdAsync(int vehicleId)
        {
            return await _context.Sales.FirstOrDefaultAsync(p => p.VehicleId == vehicleId);
        }

        public async Task AddSaleAsync(Sale Sale)
        {
            _context.Sales.Add(Sale);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSaleAsync(Sale Sale)
        {
            _context.Sales.Update(Sale);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSaleAsync(int SaleId)
        {
            Sale? sale = await _context.Sales.FindAsync(SaleId);
            if (sale is not null)
            {
                _context.Sales.Remove(sale);
                await _context.SaveChangesAsync();
            }
        }
    }
}
