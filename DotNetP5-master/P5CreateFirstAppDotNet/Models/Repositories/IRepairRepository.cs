using P5CreateFirstAppAspDotNet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5CreateFirstAppAspDotNet.Models.Repositories
{
    public interface IRepairRepository
    {
        Task AddRepairAsync(Repair repair);
        Task UpdateRepairAsync(Repair repair);
    }
}