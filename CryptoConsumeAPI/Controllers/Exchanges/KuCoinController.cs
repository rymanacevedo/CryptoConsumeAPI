using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using CryptoConsumeAPI.Models;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoConsumeAPI.Controllers
{
    [Route("api/[controller]")]
    public class KuCoinController : Controller, IExchangeController
    {
        private static string api = "http://api.kucoin.com/api/v1";
        private string currency = "USDT";
        private string coin = "BTC";
        // GET: api/kucoin
        [HttpGet]
        public async Task<string> GetAsync()
        {
            var tokens = await Processor.Start(coin, currency, "kucoin", $"prices?currencies={coin}", api);
            return tokens;

        }

        // GET api/kucoin/name
        [HttpGet("{name}")]
        public async Task<string> Get(string name)
        {
            var tokens = await Processor.Start(name, currency, "kucoin", $"prices?currencies={name}", api);
            return tokens;
        }
    }
}
