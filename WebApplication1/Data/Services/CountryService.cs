using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;
using WebApplication1.Data.DTOs;

namespace WebApplication1.Data.Services
{
    public class CountryService
    {
        private TravelContext _context;
        public CountryService(TravelContext context)
        {
            _context = context;
        }
        public async Task<Country?> AddCountry(CountryDTO countryDTO)
        {
            var trip = await _context.Trips.FirstOrDefaultAsync(trip => trip.TripId == countryDTO.TripId);
            Country country = new Country
            {
                Climate = countryDTO.Climate,
                Code = countryDTO.Code,
                CountryName = countryDTO.CountryName,
                Language = countryDTO.Language,
                NumberCities = countryDTO.NumberCities,
                Trip = trip
            };
            var result = _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            countryDTO.CountryId = result.Entity.CountryId;
            return await Task.FromResult(result.Entity);
        }
        public async Task<List<Country>> GetCountries()
        {
            var result = await _context.Countries.
                Include(country => country.Trip).
                ToListAsync();
            return await Task.FromResult(result);
        }

        public async Task<Country?> GetCountry(int id)
        {

            var result = _context.Countries.
                Include(country => country.Trip).
                FirstOrDefault(country => country.CountryId == id);
            return await Task.FromResult(result);
        }
        public async Task<Country?> UpdateCountry(int id, Country updatedCountry)
        {
            var country = await _context.Countries.
                Include(country => country.Trip).
                FirstOrDefaultAsync(country => country.CountryId == id);
            if (country != null)
            {
                country.Climate = updatedCountry.Climate;
                country.Code = updatedCountry.Code;
                country.CountryName= updatedCountry.CountryName;
                country.Language = updatedCountry.Language;
                country.NumberCities = updatedCountry.NumberCities;
                _context.Countries.Update(country);
                _context.Entry(country).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return country;
            }
            return null;
        }
        public async Task<bool> DeleteCountry(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(country => country.CountryId == id);
            if (country != null)
            {
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }

}

