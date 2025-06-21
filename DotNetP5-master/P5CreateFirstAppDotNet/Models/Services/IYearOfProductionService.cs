using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public interface IYearOfProductionService
    {
        Task<IEnumerable<YearOfProduction>> GetAllYearsOfProductionAsync();
    }
}
