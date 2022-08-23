using System.Threading;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using CryptoConsumeAPI.Models;
using System.IO;

namespace CryptoConsumeAPI.Controllers
{
    public class JsonGenerator
    {
        public static string Generate(object json, dynamic price, decimal quantity, string coin = null, string currency = "USD", string exchange = "", string pair = "", string api = "")
        {
            Asset item = new Asset(
                Guid.NewGuid().ToString(),
                coin,
                json,
                price,
                quantity,
                exchange,
                currency,
                api
            );
            return JsonSerializer.Serialize(item);
        }

        public static Task<string> GenerateAsync(object json, string coin = null, string currency = "USD", string exchange = "", string pair = "", string api = "")
        {
            Asset item = new Asset(
                Guid.NewGuid().ToString(),
                coin,
                json,
                1,
                1,
                exchange,
                currency,
                api
            );
            // return a json serialized string asynchronously
            var stream = new MemoryStream();
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return (Task<string>)JsonSerializer.SerializeAsync<Asset>(stream, item, options, new CancellationToken());
        }
    }
}   