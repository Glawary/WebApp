using BlazorApp1.Data.Models;

namespace BlazorApp1.Services
{
    public interface ICountryProvider
    {
        Task<List<Country>> GetAll();
        Task<Country> GetOne(int id);
        Task<bool> Add(Country item);
        Task<bool> Edit(int id, item);
        Task<bool> Remove(int id);

    }
}
