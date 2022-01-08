using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoConsumeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CryptoConsumeAPI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Coins> cryptoList = new List<Coins>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://api.kucoin.com/api/v1/prices"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cryptoList = JsonConvert.DeserializeObject<List<Coins>>(apiResponse);
                }
            }
            Console.WriteLine(cryptoList);
            return (IActionResult)cryptoList;
        }
    }
}   
