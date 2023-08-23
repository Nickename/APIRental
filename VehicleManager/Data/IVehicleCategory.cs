using VehicleManager.Models;

namespace VehicleManager.Data
{
    public interface IVehicleCategory
    {
        Task CreateAsync(VehicleCategory vehicleCategory);
        Task<List<VehicleCategory>> GetAllAsync();
        Task<VehicleCategory?> GetByIdAsync(int? id);
        Task UpdateAsync(VehicleCategory vehicleCategory);
        Task DeleteAsync(VehicleCategory vehicleCategory);
    }
}
