using BlazorApp1.Data.Models;

namespace BlazorApp1.Services
{
    public interface ITripProvider
    {
        Task<List<Trip>> GetAll();
        Task<Trip> GetOne(int id);
        Task<bool> Add(Trip item);
        Task<bool> Edit(int id, Trip item);
        Task<bool> Remove(int id);

    }
}
