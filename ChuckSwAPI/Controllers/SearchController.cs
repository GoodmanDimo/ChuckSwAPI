using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ChuckSwAPI.Controllers
{
    [ApiController]
    public class SearchController: ControllerBase
    {
        private readonly ILogger<SearchController> _logger;

        public SearchController(ILogger<SearchController> logger) => _logger = logger;

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SearchAsync(string query)
        {
            try
            {
                ChuckNoris.Logic.ChuckNoris chuck = new ChuckNoris.Logic.ChuckNoris();
                Swapi.Logic.Swapi swapi = new Swapi.Logic.Swapi();

                Task<Object> t1 = chuck.Search(query);
                Task<Object> t2 = swapi.Search(query);

                var SearchResults = await Task.WhenAll(t1, t2);
                var a = t1.Result.ToString();
                var b = t2.Result.ToString();

                Tuple<string, string> ab = new Tuple<string, string>(a, b);
                return Ok(ab);
            }
            catch (Exception ex)
            {
                return BadRequest("There was an error searching the Chuck Norris and Star Wars API");
            }
        }
    }
}
