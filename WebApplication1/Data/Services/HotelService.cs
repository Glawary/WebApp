using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;
using WebApplication1.Data.DTOs;

namespace WebApplication1.Data.Services
{
    public class HotelService
    {
        private TravelContext _context;
        public HotelService(TravelContext context) 
        {
            _context = context;
        }
        public async Task<Hotel?> AddHotel(HotelDTO hotelDTO)
        {
            var trip = await _context.Trips.FirstOrDefaultAsync(trip => trip.TripId == hotelDTO.TripId);
            Hotel hotel = new Hotel
            {
                HotelDescription = hotelDTO.HotelDescription,
                HotelName = hotelDTO.HotelDescription,
                HotelStatus = hotelDTO.HotelStatus,
                Trip = trip
            };
            var result = _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }
        public async Task<List<Hotel>> GetHotels()
        {
            var result = await _context.Hotels.
                Include(hotel => hotel.Trip).
                ToListAsync();
            return await Task.FromResult(result);
        }

        public async Task<Hotel?> GetHotel(int id)
        {

            var result = _context.Hotels.
                Include(hotel => hotel.Trip).
                FirstOrDefault(hotel => hotel.HotelId == id);
            return await Task.FromResult(result);
        }
        public async Task<Hotel?> UpdateHotel(int id, HotelDTO updatedHotel)
        {
            var hotel = await _context.Hotels.
                Include(hotel => hotel.Trip).
                FirstOrDefaultAsync(hotel => hotel.HotelId == id);
            if (hotel != null)
            {
                hotel.HotelName = updatedHotel.HotelName;
                hotel.HotelDescription = updatedHotel.HotelDescription;
                hotel.HotelStatus = updatedHotel.HotelStatus;
                _context.Hotels.Update(hotel);
                _context.Entry(hotel).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return hotel;
            }
            return null;
        }

        public async Task<bool> DeleteHotel(int id)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(hotel => hotel.HotelId == id);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        } 
    }

}

