﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoConsumeAPI.Controllers
{
    [Route("api/[controller]")]
    public class RouteController : Controller
    {
        private Dictionary<string, decimal>[] keyValuePairs;
        // GET: api/route
        [HttpGet("{name}")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }



        // GET api/values/5
        [HttpGet("{id}")]   
        public string Get(int id)
        {
            return "value";
        }
    }
}
