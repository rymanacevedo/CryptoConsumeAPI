using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoConsumeAPI.Controllers
{
    [Route("api/[controller]")]
    public class BinanceController : Controller, IExchangeController
    {
        private static string api = "https://api.binance.com/api/v3";
        private string currency = "USDT";
        private string coin = "BTC";
        // GET: api/binance
        [HttpGet]
        public async Task<string> GetAsync()
        {
            var tokens = await Processor.Start(coin, currency, "binance", $"ticker/price?symbol={coin}{currency}", api);
            return tokens;
        }
        // GET api/values/name
        [HttpGet("{name}")]
        public async Task<string> Get(string name)
        {
            var tokens = await Processor.Start(name, currency, "binance", $"ticker/price?symbol={name}{currency}", api);
            return tokens;
        }
    }
}
