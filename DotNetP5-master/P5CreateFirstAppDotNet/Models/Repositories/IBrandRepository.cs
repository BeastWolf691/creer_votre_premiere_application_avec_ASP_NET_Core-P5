using P5CreateFirstAppDotNet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllBrandsAsync();
        Task<Brand> GetBrandByIdAsync(int id);
        Task AddBrandAsync(Brand brand);
        Task UpdateBrandAsync(Brand brand);
        Task DeleteBrandAsync(int id);
    }
}