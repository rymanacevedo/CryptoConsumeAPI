using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Headers;
using System;
namespace CryptoConsumeAPI.Controllers
{
    public static class HTTPClientWrapper<T> where T : class
    {
       private static HttpClient client = new HttpClient();
        public static async Task<T> Get(string url)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.99 Safari/537.36");
            var streamTask = client.GetStreamAsync(url);
            var result = await JsonSerializer.DeserializeAsync<T>(await streamTask);
            return result;
        }
    }
}