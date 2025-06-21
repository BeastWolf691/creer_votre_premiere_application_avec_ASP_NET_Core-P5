using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public interface ISaleService
    {
        Task AddSaleAsync(Sale sale);
        Task<Sale?> GetSaleByIdAsync(int id);
        Task<Sale?> GetSaleByVehicleIdAsync(int vehicleId);
        Task UpdateSaleAsync(int vehicleId, VehicleViewModel vehicleViewModel);
    }
}
