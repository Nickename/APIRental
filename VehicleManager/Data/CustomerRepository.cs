using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using VehicleManager.Models;

namespace VehicleManager.Data
{
    public class CustomerRepository : ICustomer
    {
        private readonly HttpClient _client;

        public CustomerRepository(HttpClient client)
        {
            this._client = client;
        }

        public async Task CreateAsync(Customer customer)
        {
            HttpContent content = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync("/api/APICustomer", content);
            response.EnsureSuccessStatusCode();

            return;
        }

        public async Task DeleteAsync(Customer customer)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"/api/APICustomer/{customer.CustomerId}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("/api/APICustomer");
            response.EnsureSuccessStatusCode();

            string jsonContent = await response.Content.ReadAsStringAsync();
            List<Customer> customer = JsonSerializer.Deserialize<List<Customer>>(jsonContent);

            return customer;
        }

        public async Task<Customer?> GetByIdAsync(int? id)
        {
            HttpResponseMessage response = await _client.GetAsync($"/api/APICustomer/{id}");
            response.EnsureSuccessStatusCode();

            string jsonContent = await response.Content.ReadAsStringAsync();
            Customer customer = JsonSerializer.Deserialize<Customer>(jsonContent);

            return customer;
        }

        public async Task UpdateAsync(Customer customer)
        {
            HttpContent content = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PutAsync($"/api/APICustomer", content);
            response.EnsureSuccessStatusCode();

            return;
        }
    }
}