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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoConsumeAPI.Controllers
{
    [Route("api/[controller]")]
    public class KuCoinController : Controller, IExchangeController
    {
        private static readonly HttpClient client = new HttpClient();
        private static string api = "http://api.kucoin.com/api/v1";
        private static string option = "application/json";
        // GET: api/kucoin
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
            return tokens.Data;
        }

        // GET api/values/5
        [HttpGet("{name}")]
        public string Get(string name)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
