using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        // GET: api/kucoin
        [HttpGet]
        public async Task<string> GetAsync()
        {
            var tokens = await ProcessTokens();
            
            return tokens.GetRawText();

        }

        // GET api/kucoin/name
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
                builder.Append($"/prices?currencies={name}");
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var streamTask = client.GetStreamAsync(builder.ToString());
                coins = await JsonSerializer.DeserializeAsync<Coins>(await streamTask);
                result = coins.Data;
            }
            return result;
         }
  
    }
}
