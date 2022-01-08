using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoConsumeAPI.Controllers
{
    [Route("api/[controller]")]
    public class BinanceController : Controller, IExchangeController
    {
       
        private static string api = "https://api.binance.com/api/v3";
        // GET: api/binance
        [HttpGet]
        public async Task<string> GetAsync()
        {
            var tokens = await ProcessTokens();
            return tokens.GetRawText();
        }

        private static async Task<JsonElement> ProcessTokens()
        {
            var result = await HTTPClientWrapper<dynamic>.Get($"{api}/avgPrice?symbol=BTCUSDT");
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
