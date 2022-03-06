using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ChuckSwAPI.Controllers
{
    [ApiController]
    [Route("chuck")]
    public class ChuckController : ControllerBase
    {

        private readonly ILogger<ChuckController> _logger;

        public ChuckController(ILogger<ChuckController> logger) => _logger = logger;


        [HttpGet]
        [Route("categories")]
        public IActionResult categories()
        {
            try
            {
                ChuckNoris.Logic.ChuckNoris  chuck = new ChuckNoris.Logic.ChuckNoris();
                var Chuckdata = chuck.GetCategories();
                return Ok(Chuckdata);

            } catch(Exception ex)
            {
                return BadRequest("There was an error retrieving Chuck Norris API categories");
            }
        }
    }
}
