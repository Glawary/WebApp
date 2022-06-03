using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;
using WebApplication1.Data.DTOs;

namespace WebApplication1.Data.Services
{
    public class Air_FlightService
    {
        private TravelContext _context;
        public Air_FlightService(TravelContext context)
        {
            _context = context;
        }
        public async Task<Air_Flight?> AddAir_Flight(Air_FlightDTO air_flightDTO)
        {
            var trip = await _context.Trips.FirstOrDefaultAsync(trip => trip.TripId == air_flightDTO.TripId);
            Air_Flight air_flight = new Air_Flight
            {
                CompanyName = air_flightDTO.CompanyName,
                LevelComfort = air_flightDTO.LevelComfort,
                NumberHours = air_flightDTO.NumberHours,
                Trip = trip
            };
            var result = _context.Air_Flights.Add(air_flight);
            await _context.SaveChangesAsync();
            air_flight.Air_FlightId = result.Entity.Air_FlightId;
            return await Task.FromResult(result.Entity);
        }
        public async Task<List<Air_Flight>> GetAir_Flights()
        {
            var result = await _context.Air_Flights.
                Include(air_flight => air_flight.Trip).
                ToListAsync();
            return await Task.FromResult(result);
        }

        public async Task<Air_Flight?> GetAir_Flight(int id)
        {

            var result = _context.Air_Flights.
                Include(air_flight => air_flight.Trip).
                FirstOrDefault(air_flight => air_flight.Air_FlightId == id);
            return await Task.FromResult(result);
        }
        public async Task<Air_Flight?> UpdateAir_Flight(int id, Air_Flight updatedAir_Flight)
        {
            var air_flight = await _context.Air_Flights.
                Include(air_flight => air_flight.Trip).
                FirstOrDefaultAsync(air_flight => air_flight.Air_FlightId == id);
            if (air_flight != null)
            {
                air_flight.CompanyName = updatedAir_Flight. CompanyName;
                air_flight.NumberHours = updatedAir_Flight.NumberHours;
                air_flight.LevelComfort = updatedAir_Flight.LevelComfort;
                _context.Air_Flights.Update(air_flight);
                _context.Entry(air_flight).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return air_flight;
            }
            return null;
        }
        public async Task<bool> DeleteAir_Flight(int id)
        {
            var air_flight = await _context.Air_Flights.FirstOrDefaultAsync(air_flight => air_flight.Air_FlightId == id);
            if (air_flight != null)
            {
                _context.Air_Flights.Remove(air_flight);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }

}

