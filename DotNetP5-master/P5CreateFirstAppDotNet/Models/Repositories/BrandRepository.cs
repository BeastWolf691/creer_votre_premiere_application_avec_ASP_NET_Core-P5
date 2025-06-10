using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppAspDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5CreateFirstAppAspDotNet.Models.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Brand>> GetAllBrandsAsync()
        {
            return await _context.Brands.ToListAsync();
        }
        public async Task<Brand> GetBrandByIdAsync(int id)
        {
            return await _context.Brands.FindAsync(id) 
                ?? throw new KeyNotFoundException($"Brand with ID {id} not found.");
        }
        public async Task AddBrandAsync(Brand brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateBrandAsync(Brand brand)
        {
            _context.Entry(brand).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}