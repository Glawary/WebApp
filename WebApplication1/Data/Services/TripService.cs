using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.DTOs;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Services
{
    public class TripService
    {
        private TravelContext _context;
        public TripService(TravelContext context)
        {
            _context = context;
        }
        public async Task<Trip?> AddTrip(TripDTO tripDTO)
        {
            var air_flight = await _context.Air_Flights.FirstOrDefaultAsync(air_flight => air_flight.Air_FlightId == tripDTO.Air_FlightId);
            var country = await _context.Countries.FirstOrDefaultAsync(country => country.CountryId == tripDTO.CountryId);
            var hotel = await _context.Hotels.FirstOrDefaultAsync(hotel => hotel.HotelId == tripDTO.HotelId);

            if (air_flight != null && country != null && hotel != null){
                Trip trip = new Trip
                {
                    Price = tripDTO.Price,
                    NumberDays = tripDTO.NumberDays,
                    NumberStars = tripDTO.NumberStars,
                    Nutrition = tripDTO.Nutrition,
                    Picture = tripDTO.Picture,
                    LongDescription = tripDTO.LongDescription,
                    ShortDescription = tripDTO.ShortDescription,
                    Characteristics1 = tripDTO.Characteristics1,
                    Characteristics2 = tripDTO.Characteristics2,
                    Characteristics3 = tripDTO.Characteristics3,
                    Characteristics4 = tripDTO.Characteristics4,
                    Air_Flight = air_flight,
                    Country = country,
                    Hotel = hotel
                };
                if (tripDTO.CustomersIds.Any())
                {
                    trip.Customers = _context.Customers.ToList().IntersectBy(tripDTO.CustomersIds, customer => customer.CustomerId).ToList();
                }
                var result = _context.Trips.Add(trip);
                await _context.SaveChangesAsync();
                return await Task.FromResult(result.Entity);
            }
            return null;
        }
        public async Task<List<Trip>> GetTrips()
        {
            var result = await _context.Trips.
                Include(a => a.Customers).
                Include(trip => trip.Air_Flight).
                Include(trip => trip.Country).
                Include(trip => trip.Hotel).
                ToListAsync();
            return await Task.FromResult(result);
        }

        public async Task<Trip?> GetTrip(int id)
        {

            var result = _context.Trips.
                Include(a => a.Customers).
                Include(trip => trip.Air_Flight).
                Include(trip => trip.Country).
                Include(trip => trip.Hotel).
                FirstOrDefault(trip => trip.TripId == id);
            return await Task.FromResult(result);
        }

        public async Task<List<TripDTObrief>> GetTripsBrief()
        {
            var trip =  await _context.Trips.Select(trip => new TripDTObrief
            {
                TripId = trip.TripId,
                Price = trip.Price,
                NumberDays = trip.NumberDays,
                NumberStars = trip.NumberStars
            }).ToListAsync();
            return await Task.FromResult(trip);
        }
        public async Task<Trip?> UpdateTrip(int id, Trip updatedTrip)
        {
            var trip = await _context.Trips.
                Include(a => a.Customers).
                Include(trip => trip.Air_Flight).
                Include(trip => trip.Country).
                Include(trip => trip.Hotel).
                FirstOrDefaultAsync(trip => trip.TripId == id);
            if (trip != null)
            {
                trip.NumberStars = updatedTrip.NumberStars;
                trip.NumberDays = updatedTrip.NumberDays;
                trip.Nutrition = updatedTrip.Nutrition;
                trip.Picture = updatedTrip.Picture;
                trip.LongDescription = updatedTrip.LongDescription;
                trip.ShortDescription = updatedTrip.ShortDescription;
                trip.Characteristics1 = updatedTrip.Characteristics1;
                trip.Characteristics2 = updatedTrip.Characteristics2;
                trip.Characteristics3 = updatedTrip.Characteristics3;
                trip.Characteristics4 = updatedTrip.Characteristics4;
                if (updatedTrip.Customers.Any())
                {
                    trip.Customers = _context.Customers.ToList().IntersectBy(updatedTrip.Customers, customer => customer).ToList();
                }
                if (updatedTrip.Country != null)
                {
                    trip.Country = updatedTrip.Country;
                }
                if (updatedTrip.Hotel != null)
                {
                    trip.Hotel = updatedTrip.Hotel;
                }
                if (updatedTrip.Air_Flight != null)
                {
                    trip.Air_Flight = updatedTrip.Air_Flight;
                }
                _context.Trips.Update(trip);
                _context.Entry(trip).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return trip;
            }
            return null;
        }

        public async Task<bool> DeleteTrip(int id)
        {
            var trip = await _context.Trips.FirstOrDefaultAsync(trip => trip.TripId == id);
            if (trip != null)
            {
                _context.Trips.Remove(trip);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }

}
