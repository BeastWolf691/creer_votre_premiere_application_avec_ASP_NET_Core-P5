using P5CreateFirstAppDotNet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5CreateFirstAppDotNet.Models.Repositories
{
    public interface IRepairRepository
    {
        Task<IEnumerable<Repair>> GetAllRepairsAsync();
        Task<Repair?> GetRepairByIdAsync(int id);
        Task AddRepairAsync(Repair repair);
        Task UpdateRepairAsync(Repair repair);
        Task DeleteRepairAsync(int id);
        Task<Repair?> GetRepairByVehicleIdAsync(int vehicleId);

    }
}