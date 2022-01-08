﻿using System;
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
        private static string api = "http://api.kucoin.com/api/v1";
        // GET: api/kucoin
        [HttpGet]
        public async Task<string> GetAsync()
        {
            var tokens = await ProcessTokens();
            
            return tokens.GetRawText();
        }

        public async Task<JsonElement> ProcessTokens()
        {
            var result = await HTTPClientWrapper<Coins>.Get($"{api}/prices");
            return result.Data;
        }

        // GET api/values/5
        [HttpGet("{name}")]
        public string Get(string name)
        {
            throw new NotImplementedException();
        }
    }
}
