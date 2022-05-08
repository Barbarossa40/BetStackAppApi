using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BetStackAppApi.DataObjects;
using Flurl.Http;

namespace BetStackAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _webApiOptions;
        private readonly string _apiKey;
        public SportsController(IConfiguration configuration)
        {
            _configuration = configuration;
            _webApiOptions = _configuration.GetSection("WebApiOptions");
            _apiKey = _webApiOptions.GetSection("ApiKey").Value;
        }


        [HttpGet]
        public async Task<IEnumerable<SportDetails>> GetAllSports()
        {
            List<SportDetails> sportsCollection = new List<SportDetails>();
            string apiUri = "https://odds.p.rapidapi.com/v1/sports";
            var apiTask = await apiUri.WithHeaders(new
            {
                x_rapidapi_host = "odds.p.rapidapi.com",
                x_rapidapi_key = _apiKey
            }).GetJsonAsync<Sports>();

            sportsCollection.AddRange(apiTask.data);

            return sportsCollection;
        }

        [HttpGet("{key}")]
        public async Task<IEnumerable<BetEventsAndSites>> GetAllOddsByKey(string key)
        {
            key = Request.Query["key"];
            List<BetEventsAndSites> betEventsAndSites = new List<BetEventsAndSites>();
            string apiUri = $"https://odds.p.rapidapi.com/v1/odds?sport={key}&region=us&mkt=h2h&dateFormat=iso&oddsFormat=decimal";
            var apiTask = await apiUri.WithHeaders(new
            {
                x_rapidapi_host = "odds.p.rapidapi.com",
                x_rapidapi_key = _apiKey
            }).GetJsonAsync<BetEventsBySport>();
            betEventsAndSites.AddRange(apiTask.data);

            return betEventsAndSites;
        }

        // POST api/<SportsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SportsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SportsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
