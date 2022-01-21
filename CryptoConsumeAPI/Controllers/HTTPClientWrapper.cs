using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace CryptoConsumeAPI.Controllers
{
    public static class HTTPClientWrapper<T> where T : class
    {
        public static async Task<T> Get(string url)
        {
            T result = null;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applcation/json"));

                var streamTask = client.GetStreamAsync(url);
                result = await JsonSerializer.DeserializeAsync<T>(await streamTask);
            }

            return result;
        }
    }
}
