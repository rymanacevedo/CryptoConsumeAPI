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
        private static readonly HttpClient client = new HttpClient();
        private static string api = "https://api.coinmetro.com/exchange";
        private static string option = "application/json";
        // GET: api/coinmetro
        [HttpGet]
        public async Task<string> GetAsync()
        {
            var tokens = await ProcessTokens();
            return tokens.GetRawText();
        }

        private static async Task<JsonElement> ProcessTokens()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(option));
            var streamTask = client.GetStreamAsync($"{api}/prices");
            var tokens = await JsonSerializer.DeserializeAsync<Coins>(await streamTask);
            return tokens.LatestPrices;
        }
        [HttpGet("{name}")]
        public string Get(string name)
        {
            throw new NotImplementedException();
        }

        // GET: /<controller>/

    }
}
