using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Services;
using WebApplication1.Data.Models;
using WebApplication1.Data.DTOs;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Air_FlightController : ControllerBase
    {
        private readonly Air_FlightService _context;

        public Air_FlightController(Air_FlightService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Air_Flight>>> GetAir_Flights()
        {
            return await _context.GetAir_Flights();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Air_Flight>> GetAir_Flight(int id)
        {
            var air_flight = await _context.GetAir_Flight(id);

            if (air_flight == null)
            {
                return NotFound();
            }

            return Ok(air_flight);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Air_Flight>> PutAir_Flight(int id, [FromBody] Air_Flight air_flight)
        {
            var result = await _context.UpdateAir_Flight(id, air_flight);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Air_Flight>> PostAir_Flight([FromBody] Air_FlightDTO air_flightDTO)
        {
            var result = await _context.AddAir_Flight(air_flightDTO);
            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAir_Flight(int id)
        {
            var air_flight = await _context.DeleteAir_Flight(id);
            if (air_flight)
            {
                return Ok();
            }
            return BadRequest();
        }

    }

}
