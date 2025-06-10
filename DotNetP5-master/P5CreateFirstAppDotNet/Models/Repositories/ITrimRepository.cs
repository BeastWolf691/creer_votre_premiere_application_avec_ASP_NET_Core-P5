using P5CreateFirstAppDotNet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public interface ITrimRepository
    {
        Task<IEnumerable<Trim>> GetAllTrimsAsync();
        Task<Trim> GetTrimByIdAsync(int id);
        Task AddTrimAsync(Trim trim);
        Task UpdateTrimAsync(Trim trim);
    }
}