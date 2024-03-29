﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoConsumeAPI.Controllers
{
    [Route("api/[controller]")] 
    public class CoinmetroController : Controller, IExchangeController
    {
        private static string api = "https://api.coinmetro.com/exchange";
        private string currency = "USD";
        private string exchange = "coinmetro";
   
        // GET: api/coinmetro
        [HttpGet]
        public async Task<string> GetAsync(string coin = "BTC", string currency = "USD")
        {
            var tokens = await Processor.Start(coin, currency, exchange, $"prices/{coin}{currency}", api);
            return tokens;
        }
        // GET: api/coinmetro/name
        [HttpGet("{name}")]
        public async Task<string> Get(string name)
        {
            var tokens = await Processor.Start(name, currency, exchange, $"prices/{name}{currency}", api);
            return tokens;
        }

    }
}
