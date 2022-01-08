using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public async Task<JsonElement> ProcessTokens()
        {
            var result = await HTTPClientWrapper<Coins>.Get($"{api}/prices");
            return result.LatestPrices;
        }
        [HttpGet("{name}")]
        public string Get(string name)
        {
            throw new NotImplementedException();
        }
    }
}
