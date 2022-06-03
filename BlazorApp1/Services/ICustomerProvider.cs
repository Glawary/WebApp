using BlazorApp1.Data.Models;
using BlazorApp1.Data.DTOs;

namespace BlazorApp1.Services
{
    public interface ICustomerProvider
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetOne(int id);
        Task<bool> Add(CustomerDTO item);
        Task<bool> Edit(int id, CustomerDTO item);
        Task<bool> Remove(int id);

    }
}
