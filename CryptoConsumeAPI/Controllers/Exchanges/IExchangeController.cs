using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CryptoConsumeAPI.Controllers
{
    public interface IExchangeController
    {
        Task<string> Get(string name);
        Task<string> GetAsync();

    }
}
