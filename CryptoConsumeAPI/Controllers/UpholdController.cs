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
        private static string api = "https://api.uphold.com/v0/ticker";
        // GET: api/uphold
        [HttpGet]
        public async Task<string> GetAsync()
        {
            var tokens = await ProcessTokens();
            return tokens.GetRawText();
        }

        public async Task<JsonElement> ProcessTokens()
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

    }
}
