using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CryptoConsumeAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoConsumeAPI.Controllers
{
    [Route("api/[controller]")]
    public class CoinbaseController : Controller, IExchangeController
    {
        private static string api = "https://api.coinbase.com/v2/prices";
        // GET: api/coinbase
        [HttpGet]
        public async Task<string> GetAsync()
        {
            var tokens = await ProcessTokens();
            return tokens.GetRawText();
        }

        public async Task<JsonElement> ProcessTokens()
        {
            var result = await HTTPClientWrapper<Coins>.Get($"{api}/BTC-USD/buy");
            return result.Data;
        }
        // GET api/values/name
        [HttpGet("{name}")]
        public string Get(string name)
        {
            throw new NotImplementedException();
        }

     
    }
}
