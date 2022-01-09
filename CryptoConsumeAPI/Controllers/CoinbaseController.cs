using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        // GET api/coinbase/name
        [HttpGet("{name}")]
        public async Task<string> Get(string name)
        {
            var tokens = await ProcessTokens(name);
            return tokens.GetRawText();
        }

        public async Task<JsonElement> ProcessTokens(string name = null, string currency = "USD")
        {
            StringBuilder builder = new StringBuilder();
            Coins coins;
            string pair = $"{name}-{currency}";
            JsonElement result = new JsonElement();
            builder.Append(api);

            if(!String.IsNullOrEmpty(name))
            {
                builder.Append($"/{pair}/buy");
                coins = await HTTPClientWrapper<Coins>.Get(builder.ToString());
                result = coins.Data;
            }
            return result;
        }


     
    }
}
