using Microsoft.AspNetCore.Mvc;
using BetStackAppApi.DataObjects;
using Flurl.Http;

namespace BetStackAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OddsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _webApiOptions;
        private readonly string _apiKey;
        public OddsController(IConfiguration configuration)
        {
            _configuration = configuration;
            _webApiOptions = _configuration.GetSection("WebApiOptions");
            _apiKey = _webApiOptions.GetSection("ApiKey").Value;
        }


        // GET api/<OddsController>/5
        [HttpGet("{key}")]
        public async Task<IEnumerable<BetEventsAndSites>> GetAllOddsByKey(string key)
        {
            List<BetEventsAndSites> betEventsAndSites = new List<BetEventsAndSites>();
            key = Request.Query["key"];
            string apiUri = $"https://odds.p.rapidapi.com/v1/odds?sport={key}&region=us&mkt=h2h&dateFormat=iso&oddsFormat=decimal";
            var apiTask = await apiUri.WithHeaders(new
            {
                x_rapidapi_host = "odds.p.rapidapi.com",
                x_rapidapi_key = _apiKey
            }).GetJsonAsync<BetEventsBySport>();
            betEventsAndSites.AddRange(apiTask.data);

            return (betEventsAndSites);
        }

        [HttpGet("{id}")]
        public IEnumerable<SiteItems> GetSitesAndOddsById(string key, string id)
        {
            List<SiteItems> _siteItems = new List<SiteItems>();

            return _siteItems;
        }

        // POST api/<OddsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OddsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OddsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
