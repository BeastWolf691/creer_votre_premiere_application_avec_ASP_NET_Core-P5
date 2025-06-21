using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public interface IYearOfProductionRepository
    {
        Task<IEnumerable<YearOfProduction>> GetAllYearsAsync();
    }
}
