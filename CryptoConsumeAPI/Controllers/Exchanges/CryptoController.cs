﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoConsumeAPI.Controllers
{
    [Route("api/[controller]")]
    public class CryptoController : Controller, IExchangeController
    {
        private static string api = "https://api.crypto.com/v2";
        private string currency = "USDT";
        private string exchange = "crypto";
        // GET: api/crypto
        [HttpGet]
        public async Task<string> GetAsync(string coin = "BTC", string currency = "USDT")
        {
            var tokens = await Processor.Start(coin, currency, exchange, $"public/get-ticker?instrument_name={coin}_{currency}", api);
            return tokens;
        }

        // GET api/crypto/name
        [HttpGet("{name}")]
        public async Task<string> Get(string name)
        {
            var tokens = await Processor.Start(name, currency, exchange, $"public/get-ticker?instrument_name={name}_{currency}", api);
            return tokens;
        }
    }
}
