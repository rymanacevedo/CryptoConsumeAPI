using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using CryptoConsumeAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoConsumeAPI.Controllers
{
    [Route("api/[controller]")]
    public class UpholdController : Controller, IExchangeController
    {
        private static readonly HttpClient client = new HttpClient();
        private static string api = "https://api.uphold.com/v0/ticker";
        private static string option = "application/json";
        [HttpGet]
        public async Task<string> GetAsync()
        {
            var tokens = await ProcessTokens();
            return tokens.GetRawText();
        }

        private static async Task<JsonElement> ProcessTokens()
        {
            var result = await HTTPClientWrapper<dynamic>.Get($"{api}/BTC");
            return result;
        }
        // GET api/values/name
        [HttpGet("{name}")]
        public string Get(string name)
        {
            throw new NotImplementedException();
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
