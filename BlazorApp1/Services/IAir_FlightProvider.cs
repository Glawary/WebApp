using BlazorApp1.Data.Models;

namespace BlazorApp1.Services
{
    public interface IAir_FlightProvider
    {
        Task<List<Air_Flight>> GetAll();
        Task<Air_Flight> GetOne(int id);
        Task<bool> Add(Air_Flight item);
        Task<bool> Edit(int id, Air_Flight item);
        Task<bool> Remove(int id);

    }
}
