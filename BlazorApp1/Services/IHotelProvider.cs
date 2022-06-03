using BlazorApp1.Data.Models;
using BlazorApp1.Data.DTOs;

namespace BlazorApp1.Services
{
    public interface IHotelProvider
    {
        Task<List<Hotel>> GetAll();
        Task<Hotel> GetOne(int id);
        Task<bool> Add(Hotel item);
        Task<bool> Edit(int id, Hotel item);
        Task<bool> Remove(int id);

    }
}
