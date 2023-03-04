using Flights.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Flights.ReadModels;

namespace Flights.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        static private List<NewPassengerDto> Passengers = new List<NewPassengerDto>(); 
      
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Register(NewPassengerDto dto)
        {
            Passengers.Add(dto);
            System.Diagnostics.Debug.WriteLine(Passengers.Count);
            return CreatedAtAction(nameof(Find), new { email = dto.Email });
        }

        [HttpGet("{email}")]
        public ActionResult<PassengerRm> Find(string email)
        {
            var passenger = Passengers.FirstOrDefault(e => e.Email == email);

            if (passenger == null)
                return NotFound();

            var rm = new PassengerRm(
                passenger.Email,
                passenger.FirstName,
                passenger.LastName,
                passenger.Gender);

            return Ok(rm);
        }
    }
}
