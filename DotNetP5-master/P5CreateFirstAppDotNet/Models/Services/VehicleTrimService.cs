using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.Repositories;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Models.Services
{
    public class VehicleTrimService : IVehicleTrimService
    {
        private readonly IVehicleTrimRepository _vehicleTrimRepository;
        public VehicleTrimService(IVehicleTrimRepository vehicleTrimRepository)
        {
            _vehicleTrimRepository = vehicleTrimRepository;
        }
        public async Task<IEnumerable<VehicleTrim>> GetAllVehicleTrimsAsync()
        {
            return await _vehicleTrimRepository.GetAllVehicleTrimsAsync();
        }

        public async Task<VehicleTrim> GetVehicleTrimByIdAsync(int trimId)
        {
            return await _vehicleTrimRepository.GetVehicleTrimByIdAsync(trimId);
        }
        public async Task<VehicleTrim> AddNewVehicleTrimAsync(string trimLabel)
        {
            VehicleTrim existingTrim = await _vehicleTrimRepository.GetVehicleTrimByNameAsync(trimLabel);
            if (existingTrim != null)
            {
                throw new InvalidOperationException("Cette finition existe déjà.");
            }

            VehicleTrim newTrim = new VehicleTrim { TrimLabel = trimLabel };
            await _vehicleTrimRepository.AddVehicleTrimAsync(newTrim);

            return newTrim;
        }

    }
}
