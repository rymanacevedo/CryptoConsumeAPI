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
        private string currency = "USD";
        private string coin = "BTC";
        // GET: api/uphold
        [HttpGet]
        public async Task<string> GetAsync()
        {
            var tokens = await Processor.Start(coin, currency, "uphold", $"{coin}-{currency}", api);
            return tokens;
        }
        // GET api/values/name
        [HttpGet("{name}")]
        public async Task<string> Get(string name)
        {
            var tokens = await Processor.Start(name, currency, "uphold", $"{name}-{currency}", api);
            return tokens;
        }

    }
}
