using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CryptoConsumeAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoConsumeAPI.Controllers
{
    [Route("api/[controller]")] 
    public class CoinmetroController : Controller, IExchangeController
    {
        private static string api = "https://api.coinmetro.com/exchange";
   
        // GET: api/coinmetro
        [HttpGet]
        public async Task<string> GetAsync()
        {
            var tokens = await ProcessTokens();
            return tokens.GetRawText();
        }
        // GET: api/coinmetro/name
        [HttpGet("{name}")]
        public async Task<string> Get(string name)
        {
            var tokens = await ProcessTokens(name);
            return tokens.GetRawText();
        }

        public async Task<JsonElement> ProcessTokens(string name = null)
        {
            StringBuilder builder = new StringBuilder();
            Coins coins;
            JsonElement result = new JsonElement();
            builder.Append(api);

            if (!String.IsNullOrEmpty(name))
            {
                builder.Append("/prices");
                coins = await HTTPClientWrapper<Coins>.Get(builder.ToString());
                result = coins.LatestPrices;
            }
            return result;
        }

    }
}
