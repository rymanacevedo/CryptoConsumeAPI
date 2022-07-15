using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
namespace CryptoConsumeAPI.Controllers
{
    public static class HTTPClientWrapper<T> where T : class
    {
        private static HttpClient client = new HttpClient();
        public static async Task<object> Get(string url)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Clear();
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(json);
            }
            // return object with error message
            return new { value = "Not Found" };
        }
    }
}