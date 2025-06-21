using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public interface IPurchaseService
    {
        Task<Purchase?> GetPurchaseByVehicleIdAsync(int vehicleId);
        Task AddPurchaseAsync(Purchase purchase);
        Task UpdatePurchaseAsync(int vehicleId, VehicleViewModel vehicleViewModel);
    }
}
