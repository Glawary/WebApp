using System.Net.Http.Json;
using Newtonsoft.Json;
using BlazorApp1.Data.Models;

namespace BlazorApp1.Services
{
    public class CountryProvider : ICountryProvider
    {
        private readonly HttpClient _httpClient;
        public CountryProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Country>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Country>>("/api/Country");
        }
        public async Task<Country> GetOne(int id)
        {
            return await _httpClient.GetFromJsonAsync<Country>($"/api/Country/{id}");
        }
        public async Task<bool> Add(Country item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _httpClient.PostAsync($"/api/Country", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<bool> Edit(int id, Country item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _httpClient.PutAsync($"/api/Country/{id}", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await _httpClient.DeleteAsync($"/api/Country/{id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);

        }
    }
}
