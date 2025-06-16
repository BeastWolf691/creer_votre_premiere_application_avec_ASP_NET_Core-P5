using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandViewModel>> GetAllBrandsAsync();
        Task<BrandViewModel> GetBrandByIdAsync(int id);
        Task AddBrandAsync(BrandViewModel brandViewModel);
        Task UpdateBrandAsync(BrandViewModel brandViewModel);
        Task DeleteBrandAsync(int id);
        BrandViewModel MapToViewModel(Brand brand);
    }
}
