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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoConsumeAPI.Controllers
{
    [Route("api/[controller]")]
    public class UpholdController : Controller, IExchangeController
    {
        private static string api = "https://api.uphold.com/v0/ticker";
        // GET: api/uphold
        [HttpGet]
        public async Task<string> GetAsync()
        {
            var tokens = await ProcessTokens();
            return tokens.GetRawText();
        }
        // GET api/values/name
        [HttpGet("{name}")]
        public async Task<string> Get(string name)
        {
            var tokens = await ProcessTokens(name);
            return tokens.GetRawText();
        }
        public async Task<JsonElement> ProcessTokens(string name = null, string currency = "USD")
        {
            StringBuilder builder = new StringBuilder();
            JsonElement result = new JsonElement();
            string pair = $"{name}-{currency}";
            builder.Append(api);

            if (!String.IsNullOrEmpty(name))
            {
                builder.Append($"/{pair}");
                result = await HTTPClientWrapper<dynamic>.Get(builder.ToString());
            }
            return result;
        }


    }
}
