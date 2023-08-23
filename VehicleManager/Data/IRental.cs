using VehicleManager.Models;

namespace VehicleManager.Data
{
    public interface IRental
    {
        Task CreateAsync(Rental rental);
        Task<List<Rental>> GetAllAsync();
        Task<List<Rental>> GetAllAsync(string filter);
        Task<Rental?> GetByIdAsync(int? id);
        Task UpdateAsync(Rental rental);
        Task DeleteAsync(Rental rental);
    }
}
