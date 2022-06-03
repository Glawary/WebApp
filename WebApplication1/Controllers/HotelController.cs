using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Services;
using WebApplication1.Data.Models;
using WebApplication1.Data.DTOs;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HotelController : ControllerBase
    {
        private readonly HotelService _context;

        public HotelController(HotelService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            return await _context.GetHotels();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await _context.GetHotel(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Hotel>> PutHotel(int id, [FromBody] HotelDTO hotelDTO)
        {
            var result = await _context.UpdateHotel(id, hotelDTO);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel([FromBody] HotelDTO hotelDTO)
        {
            var result = await _context.AddHotel(hotelDTO);
            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _context.DeleteHotel(id);
            if (hotel)
            {
                return Ok();
            }
            return BadRequest();
        }

    }

}
