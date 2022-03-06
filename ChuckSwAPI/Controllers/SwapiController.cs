using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace ChuckSwAPI.Controllers
{
    [ApiController]
    [Route("swapi")]
    public class SwapiController : ControllerBase
    {
        private readonly ILogger<SwapiController> _logger;

        public SwapiController(ILogger<SwapiController> logger) => _logger = logger;

        [HttpGet]
        [Route("people")]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public IActionResult people()
        {
            try
            {
                Swapi.Logic.Swapi swapi = new Swapi.Logic.Swapi();

                var Swapi = swapi.GetPeople();

                return Ok(Swapi);
            }
            catch (Exception ex)
            {
                return BadRequest("There was an error retieving the People from the star wars API");
            }
          
        }
    }
}
