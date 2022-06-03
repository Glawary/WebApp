using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Services;
using WebApplication1.Data.Models;
using WebApplication1.Data.DTOs;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CountryController : ControllerBase
    {
        private readonly CountryService _context;

        public CountryController(CountryService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return await _context.GetCountries();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _context.GetCountry(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Country>> PutCountry(int id, [FromBody] Country country)
        {
            var result = await _context.UpdateCountry(id, country);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry([FromBody] CountryDTO countryDTO)
        {
            var result = await _context.AddCountry(countryDTO);
            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _context.DeleteCountry(id);
            if (country)
            {
                return Ok();
            }
            return BadRequest();
        }

    }

}
