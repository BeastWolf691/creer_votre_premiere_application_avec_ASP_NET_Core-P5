using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetAllSalesAsync();
        Task<Sale?> GetSaleByIdAsync(int SaleId);
        Task<Sale?> GetSaleByVehicleIdAsync(int vehicleId);
        Task AddSaleAsync(Sale Sale);
        Task UpdateSaleAsync(Sale Sale);
        Task DeleteSaleAsync(int SaleId);
    }
}
