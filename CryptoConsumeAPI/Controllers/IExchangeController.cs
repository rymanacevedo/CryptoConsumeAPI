using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CryptoConsumeAPI.Controllers
{
    public interface IExchangeController
    {
        string Get(string name);
        Task<string> GetAsync();
    }
}
