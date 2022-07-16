using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoConsumeAPI.Controllers
{
    [Route("api/[controller]")]
    public class KuCoinController : Controller, IExchangeController
    {
        private static string api = "http://api.kucoin.com/api/v1";
        private string currency = "USDT";
        private string exchange = "kucoin";
        // GET: api/kucoin
        [HttpGet]
        public async Task<string> GetAsync(string coin = "BTC", string currency = "USD")
        {
            var tokens = await Processor.Start(coin, currency, exchange, $"prices?currencies={coin}", api);
            return tokens;

        }

        // GET api/kucoin/name
        [HttpGet("{name}")]
        public async Task<string> Get(string name)
        {
            var tokens = await Processor.Start(name, currency, exchange, $"prices?currencies={name}", api);
            return tokens;
        }
    }
}
