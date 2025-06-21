using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public interface IPurchaseRepository
    {
        Task<IEnumerable<Purchase>> GetAllPurchasesAsync();
        Task<Purchase?> GetPurchaseByIdAsync(int purchaseId);
        Task<Purchase?> GetPurchaseByVehicleIdAsync(int vehicleId);
        Task AddPurchaseAsync(Purchase purchase);
        Task UpdatePurchaseAsync(Purchase purchase);
        Task DeletePurchaseAsync(int purchaseId);
    }
}
