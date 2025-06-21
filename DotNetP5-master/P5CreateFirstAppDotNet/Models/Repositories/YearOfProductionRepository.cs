using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Data;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public class YearOfProductionRepository : IYearOfProductionRepository
    {
        private readonly ApplicationDbContext _context;

        public YearOfProductionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<YearOfProduction>> GetAllYearsAsync()
        {
            return await _context.YearOfProductions.ToListAsync();
        }
    }
}
