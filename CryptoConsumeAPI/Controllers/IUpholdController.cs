using System.Threading.Tasks;

namespace CryptoConsumeAPI.Controllers
{
    public interface IUpholdController
    {
        string Get(int id);
        Task<string> GetAsync();
    }
}