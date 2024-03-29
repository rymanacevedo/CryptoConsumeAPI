﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoConsumeAPI.Controllers
{
    [Route("api/[controller]")]
    public class CoinbaseController : Controller, IExchangeController
    {
        private static string api = "https://api.coinbase.com/v2/prices";
        private string currency = "USD";
        private string exchange = "coinbase";
        // GET: api/coinbase
        [HttpGet]
        public async Task<string> GetAsync(string coin = "BTC", string currency = "USD")
        {
            var tokens = await Processor.Start(coin, currency, exchange, $"{coin}-{currency}/buy", api);
            return tokens;
        }
        // GET api/coinbase/name
        [HttpGet("{name}")]
        public async Task<string> Get(string name)
        {
            var tokens = await Processor.Start(name, currency, exchange, $"{name}-{currency}/buy", api);
            return tokens;
        }
     
    }
}
