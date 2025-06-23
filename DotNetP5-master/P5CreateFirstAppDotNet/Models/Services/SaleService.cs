using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.Repositories;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task AddSaleAsync(Sale sale)
        {
            await _saleRepository.AddSaleAsync(sale);
        }

        public async Task<Sale?> GetSaleByIdAsync(int id)
        {
            return await _saleRepository.GetSaleByIdAsync(id);
        }

        public async Task<Sale?> GetSaleByVehicleIdAsync(int vehicleId)
        {
            return await _saleRepository.GetSaleByVehicleIdAsync(vehicleId);
        }

        public async Task UpdateSaleAsync(int vehicleId, VehicleViewModel vehicleViewModel)
        {
            Sale? sale = await GetSaleByVehicleIdAsync(vehicleId);
            if (sale is null)
            {
                sale = new Sale
                {
                    VehicleId = vehicleId,
                    SaleDate = vehicleViewModel.SaleDate,
                    SalePrice = vehicleViewModel.SalePrice ?? 0
                };
                await _saleRepository.AddSaleAsync(sale);
                return;
            }
            if (vehicleViewModel.SaleDate.HasValue)
                sale.SaleDate = vehicleViewModel.SaleDate.Value;

            if (vehicleViewModel.SalePrice.HasValue)
                sale.SalePrice = vehicleViewModel.SalePrice.Value;

            await _saleRepository.UpdateSaleAsync(sale);
        }
    }
}
