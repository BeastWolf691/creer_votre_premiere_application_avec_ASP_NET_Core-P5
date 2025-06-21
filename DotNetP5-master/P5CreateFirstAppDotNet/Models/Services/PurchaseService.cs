using System.Globalization;
using Microsoft.Extensions.Localization;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.Repositories;
using P5CreateFirstAppDotNet.Models.ViewModels;
using System.Collections.Generic;
namespace P5CreateFirstAppDotNet.Models.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task<Purchase?> GetPurchaseByVehicleIdAsync(int vehicleId)
        {
            return await _purchaseRepository.GetPurchaseByVehicleIdAsync(vehicleId);
        }

        public async Task AddPurchaseAsync(Purchase purchase)
        {
            await _purchaseRepository.AddPurchaseAsync(purchase);
        }

        public async Task UpdatePurchaseAsync(int vehicleId, VehicleViewModel vehicleViewModel)
        {
            Purchase? purchase = await GetPurchaseByVehicleIdAsync(vehicleId);
            if (purchase is null)
                return;

            if (vehicleViewModel.PurchaseDate.HasValue)
                purchase.PurchaseDate = vehicleViewModel.PurchaseDate.Value;

            purchase.PurchasePrice = vehicleViewModel.PurchasePrice;

            await _purchaseRepository.UpdatePurchaseAsync(purchase);
        }
    }
}
