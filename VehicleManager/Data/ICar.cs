using VehicleManager.Models;

namespace VehicleManager.Data
{
    public interface ICar
    {
        Task CreateAsync(Car car);
        Task<List<Car>> GetAllAsync();
        Task<List<Car>> GetAllAsync(string filter);
        Task<Car?> GetByIdAsync(int? id);
        Task UpdateAsync(Car car);
        Task DeleteAsync(Car car);
    }
}
