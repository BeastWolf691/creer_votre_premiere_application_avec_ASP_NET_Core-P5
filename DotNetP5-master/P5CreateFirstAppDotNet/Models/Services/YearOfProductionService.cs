using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.Repositories;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public class YearOfProductionService : IYearOfProductionService
    {
        private readonly IYearOfProductionRepository _yearOfProductionRepository;

        public YearOfProductionService(IYearOfProductionRepository yearOfProductionRepository)
        {
            _yearOfProductionRepository = yearOfProductionRepository;
        }
        public async Task<IEnumerable<YearOfProduction>> GetAllYearsOfProductionAsync()
        {
            return await _yearOfProductionRepository.GetAllYearsAsync();
        }
    }
}
