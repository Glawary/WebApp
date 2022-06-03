using System.Net.Http.Json;
using Newtonsoft.Json;
using BlazorApp1.Data.Models;

namespace BlazorApp1.Services
{
    public class TripProvider : ITripProvider
    {
        private readonly HttpClient _httpClient;
        public TripProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Trip>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Trip>>("/api/Trip");
        }
        public async Task<Trip> GetOne(int id)
        {
            return await _httpClient.GetFromJsonAsync<Trip>($"/api/Trip/{id}");
        }
        public async Task<bool> Add(Trip item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _httpClient.PostAsync($"/api/Trip", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<bool> Edit(int id, Trip item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _httpClient.PutAsync($"/api/Trip/{id}", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await _httpClient.DeleteAsync($"/api/Trip/${id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);

        }
    }
}
