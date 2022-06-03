using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Services;
using WebApplication1.Data.DTOs;
using WebApplication1.Data.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TripController : ControllerBase
    {
        private readonly TripService _context;

        public TripController(TripService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trip>>> GetTrips()
        {
            return await _context.GetTrips();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trip>> GetTrip(int id)
        {
            var trip = await _context.GetTrip(id);

            if (trip == null)
            {
                return NotFound();
            }

            return Ok(trip);
        }

        [HttpGet("/brief")]
        public async Task<ActionResult<IEnumerable<TripDTObrief>>> GetTripsBrief()
        {
            return await _context.GetTripsBrief();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Trip>> PutTrip(int id, [FromBody] Trip trip)
        {
            var result = await _context.UpdateTrip(id, trip);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Trip>> PostTrip([FromBody] TripDTO tripDTO)
        {
            var result = await _context.AddTrip(tripDTO);
            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrip(int id)
        {
            var trip = await _context.DeleteTrip(id);
            if (trip)
            {
                return Ok();
            }
            return BadRequest();
        }

    }

}
