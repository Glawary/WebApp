using System.Net.Http.Json;
using Newtonsoft.Json;
using BlazorApp1.Data.Models;

namespace BlazorApp1.Services
{
    public class Air_FlightProvider : IAir_FlightProvider
    {
        private readonly HttpClient _httpClient;
        public Air_FlightProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Air_Flight>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Air_Flight>>("/api/Air_Flight");
        }
        public async Task<Air_Flight> GetOne(int id)
        {
            return await _httpClient.GetFromJsonAsync<Air_Flight>($"/api/Air_Flight/{id}");
        }
        public async Task<bool> Add(Air_Flight item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _httpClient.PostAsync($"/api/Air_Flight", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<bool> Edit(int id, Air_Flight item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _httpClient.PutAsync($"/api/Air_Flight/{id}", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await _httpClient.DeleteAsync($"/api/Air_Flight/{id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);

        }
    }
}
