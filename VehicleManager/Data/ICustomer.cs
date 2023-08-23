using VehicleManager.Models;

namespace VehicleManager.Data
{
    public interface ICustomer
    {
        Task CreateAsync(Customer customer);
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int? id);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Customer customer);
    }
}
