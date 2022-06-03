using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;
using WebApplication1.Data.DTOs;

namespace WebApplication1.Data.Services
{
    public class CustomerService
    {
        private TravelContext _context;
        public CustomerService(TravelContext context)
        {
            _context = context;
        }
        public async Task<Customer?> AddCustomer(CustomerDTO customerDTO)
        {
            var trip = await _context.Trips.FirstOrDefaultAsync(trip => trip.TripId == customerDTO.TripId);
            Customer customer = new Customer
            {
                FullName = customerDTO.FullName,
                Email = customerDTO.Email,
                PhoneNumber = customerDTO.PhoneNumber,
                Trip = trip
            };
            var result = _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }
        public async Task<List<Customer>> GetCustomers()
        {
            var result = await _context.Customers.
                Include(customer => customer.Trip).
                ToListAsync();
            return await Task.FromResult(result);
        }

        public async Task<Customer?> GetCustomer(int id)
        {
            var result = _context.Customers.
                Include(customer => customer.Trip).
                FirstOrDefault(customer => customer.CustomerId == id);
            return await Task.FromResult(result);
        }
        public async Task<Customer?> UpdateCustomer(int id, CustomerDTO updatedCustomer)
        {
            var customer = await _context.Customers.
                Include(customer => customer.Trip).
                FirstOrDefaultAsync(customer => customer.CustomerId == id);
            if (customer != null)
            {
                customer.FullName = updatedCustomer.FullName;
                customer.Email = updatedCustomer.Email;
                customer.PhoneNumber = updatedCustomer.PhoneNumber;
                _context.Customers.Update(customer);
                _context.Entry(customer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return customer;
            }
            return null;
        }
        public async Task<bool> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(customer => customer.CustomerId == id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }

}

