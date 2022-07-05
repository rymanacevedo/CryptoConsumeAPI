using System.Threading.Tasks;

namespace CryptoConsumeAPI.Controllers
{
    public interface IExchangeController
    {
        Task<string> Get(string name);
        Task<string> GetAsync();

    }
}
