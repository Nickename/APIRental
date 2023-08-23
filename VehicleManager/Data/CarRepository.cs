using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using VehicleManager.Models;

namespace VehicleManager.Data
{
    public class CarRepository : ICar
    {
        private readonly HttpClient _client;

        public CarRepository(HttpClient client)
        {
            this._client = client;
        }

        public async Task CreateAsync(Car car)
        {
            HttpContent content = new StringContent(JsonSerializer.Serialize(car), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync("/api/APICar", content);
            response.EnsureSuccessStatusCode();
            return;
        }

        public async Task DeleteAsync(Car car)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"/api/APICar/{car.CarId}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Car>> GetAllAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("/api/APICar");
            response.EnsureSuccessStatusCode();

            string jsonContent = await response.Content.ReadAsStringAsync();
            List<Car> cars = JsonSerializer.Deserialize<List<Car>>(jsonContent);

            return cars;
        }

        public async Task<List<Car>> GetAllAsync(string filter)
        {
            HttpResponseMessage response = await _client.GetAsync($"/api/APICar/filter/{filter}");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var cars = JsonSerializer.Deserialize<List<Car>>(jsonResponse);

            return cars;
        }

        public async Task<Car?> GetByIdAsync(int? id)
        {
            HttpResponseMessage response = await _client.GetAsync($"/api/APICar/{id}");
            response.EnsureSuccessStatusCode();

            string jsonContent = await response.Content.ReadAsStringAsync();
            Car car = JsonSerializer.Deserialize<Car>(jsonContent);

            return car;
        }

        public async Task UpdateAsync(Car car)
        {
            HttpContent content = new StringContent(JsonSerializer.Serialize(car), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PutAsync($"/api/APICar", content);
            response.EnsureSuccessStatusCode();

            return;
        }
    }
}
