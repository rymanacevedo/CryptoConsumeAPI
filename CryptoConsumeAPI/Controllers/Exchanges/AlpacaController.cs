using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CryptoConsumeAPI.Controllers
{
    [Route("api/[controller]")]
    public class AlpacaController : Controller, IExchangeController
    {
        private static string api = "https://data.alpaca.markets/v1beta2/crypto";
        private string currency = "USD";
        private string exchange = "alpaca";
        // GET: api/alpca
        [HttpGet]
        public async Task<string> GetAsync(string coin = "BTC", string currency = "USD")
        {
            var tokens = await Processor.Start(coin, currency, exchange, $"latest/quotes?symbols={coin}/{currency}", api);
            return tokens;
        }
        // GET api/alpca/name
        [HttpGet("{name}")]
        public async Task<string> Get(string name)
        {
            var tokens = await Processor.Start(name, currency, exchange, $"{name}/day", api);
            return tokens;
        }
    }
}