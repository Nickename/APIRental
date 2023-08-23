using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using VehicleManager.Models;

namespace VehicleManager.Data
{
    public class VehicleCategoryRepository : IVehicleCategory
    {
        private readonly HttpClient _client;

        public VehicleCategoryRepository(HttpClient client)
        {
            this._client = client; 
        }

        public async Task CreateAsync(VehicleCategory vehicleCategory)
        {
            string vehicleCategoryJson = JsonSerializer.Serialize(vehicleCategory);
            StringContent content = new StringContent(vehicleCategoryJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync("/api/APIVehicleCategory", content);
            response.EnsureSuccessStatusCode();
            return;
        }

        public async Task DeleteAsync(VehicleCategory vehicleCategory)
        {
            //string url = $"/api/APIVehicleCategory/{vehicleCategory.VehicleCategoryId}";
            HttpResponseMessage response = await _client.DeleteAsync($"/api/APIVehicleCategory/{vehicleCategory.VehicleCategoryId}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<VehicleCategory>> GetAllAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("/api/APIVehicleCategory");

            response.EnsureSuccessStatusCode(); // Throw an exception if the request fails
            string jsonContent = await response.Content.ReadAsStringAsync();
            List<VehicleCategory> vehicleCategory = JsonSerializer.Deserialize<List<VehicleCategory>>(jsonContent);

            return vehicleCategory;
        }

        public async Task<VehicleCategory?> GetByIdAsync(int? id)
        {
            HttpResponseMessage response = await _client.GetAsync($"/api/APIVehicleCategory/{id}");
            string jsonContent = await response.Content.ReadAsStringAsync();
            VehicleCategory vehicleCategory = JsonSerializer.Deserialize<VehicleCategory>(jsonContent);

            return vehicleCategory;
        }

        public async Task UpdateAsync(VehicleCategory vehicleCategory)
        {
            HttpContent content = new StringContent(JsonSerializer.Serialize(vehicleCategory), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync($"/api/APIVehicleCategory", content);
            response.EnsureSuccessStatusCode();
            return;
        }
    }
}