using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using VehicleManager.Models;

namespace VehicleManager.Data
{
    public class RentalRepository : IRental
    {
        private readonly HttpClient _client;

        public RentalRepository(HttpClient client)
        {
            this._client = client;           
        }

        public async Task CreateAsync(Rental rental)
        {
            HttpContent content = new StringContent(JsonSerializer.Serialize(rental), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync("/api/APIRental", content);
            response.EnsureSuccessStatusCode();
            return;
        }

        public async Task DeleteAsync(Rental rental)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"/api/APIRental/{rental.RentalId}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Rental>> GetAllAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("/api/APIRental");
            response.EnsureSuccessStatusCode();

            string jsonContent = await response.Content.ReadAsStringAsync();
            List<Rental> rentals = JsonSerializer.Deserialize<List<Rental>>(jsonContent);

            return rentals;
        }

        public async Task<List<Rental>> GetAllAsync(string filter)
        {
            HttpResponseMessage response = await _client.GetAsync($"/api/APIRental/filter/{filter}");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var rentals = JsonSerializer.Deserialize<List<Rental>>(jsonResponse);

            return rentals;
        }

        public async Task<Rental?> GetByIdAsync(int? id)
        {
            HttpResponseMessage response = await _client.GetAsync($"/api/APIRental/{id}");
            response.EnsureSuccessStatusCode();

            string jsonContent = await response.Content.ReadAsStringAsync();
            Rental rental = JsonSerializer.Deserialize<Rental>(jsonContent);

            return rental;
        }

        public async Task UpdateAsync(Rental rental)
        {
            HttpContent content = new StringContent(JsonSerializer.Serialize(rental), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PutAsync($"/api/APIRental", content);
            response.EnsureSuccessStatusCode();

            return;
        }
    }
}