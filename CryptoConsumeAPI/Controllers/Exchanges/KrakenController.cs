using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CryptoConsumeAPI.Controllers
{
    [Route("api/[controller]")]
    public class KrakenController : Controller, IExchangeController
    {
        private static string api = "https://api.kraken.com/0/public/Ticker";
        private string currency = "USD";
        private string coin = "BTC";
        private string exchange = "kraken";
        // GET: api/kraken
        [HttpGet]
        public async Task<string> GetAsync()
        {
            var tokens = await Processor.Start(coin, currency, exchange, $"?pair={coin}{currency}", api);
            return tokens;
        }
        // GET api/kraken/name
        [HttpGet("{name}")]
        public async Task<string> Get(string name)
        {
            var tokens = await Processor.Start(name, currency, exchange, $"?pair={name}{currency}", api);
            return tokens;
        }
    }
}