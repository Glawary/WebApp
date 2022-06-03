using System.Net.Http.Json;
using Newtonsoft.Json;
using BlazorApp1.Data.Models;

namespace BlazorApp1.Services
{
    public class HotelProvider : IHotelProvider
    {
        private readonly HttpClient _httpClient;
        public HotelProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Hotel>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Hotel>>("/api/Hotel");
        }
        public async Task<Hotel> GetOne(int id)
        {
            return await _httpClient.GetFromJsonAsync<Hotel>($"/api/Hotel/{id}");
        }
        public async Task<bool> Add(Hotel item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _httpClient.PostAsync($"/api/Hotel", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<bool> Edit(int id, Hotel item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _httpClient.PutAsync($"/api/Hotel/{id}", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await _httpClient.DeleteAsync($"/api/Hotel/{id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);

        }
    }
}
