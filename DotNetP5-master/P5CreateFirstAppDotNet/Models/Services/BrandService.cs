using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.Repositories;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository, IBrandService brandService)
        {
            _brandRepository = brandRepository;
        }

        public async Task<IEnumerable<BrandViewModel>> GetAllBrandsAsync()
        {
            var brands = await _brandRepository.GetAllBrandsAsync();
            return brands.Select(MapToViewModel);
        }

        public async Task<BrandViewModel> GetBrandByIdAsync(int id)
        {
            var brand = await _brandRepository.GetBrandByIdAsync(id);
            return MapToViewModel(brand);
        }

        public async Task AddBrandAsync(BrandViewModel brandViewModel)
        {
            var brand = MapToEntity(brandViewModel);
            await _brandRepository.AddBrandAsync(brand);
        }

        public async Task UpdateBrandAsync(BrandViewModel brandViewModel)
        {
            var brand = MapToEntity(brandViewModel);
            await _brandRepository.UpdateBrandAsync(brand);
        }

        public async Task DeleteBrandAsync(int id)
        {
            await _brandRepository.DeleteBrandAsync(id);
        }

        public BrandViewModel MapToViewModel(Brand brand)
        {
            return new BrandViewModel
            {
                BrandId = brand.BrandId,
                Name = brand.Name
            };
        }

        private Brand MapToEntity(BrandViewModel brandViewModel)
        {
            return new Brand
            {
                BrandId = brandViewModel.BrandId,
                Name = brandViewModel.Name
            };

        }
    }
}
