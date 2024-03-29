using System;
using System.Threading.Tasks;
using CryptoConsumeAPI.Controllers;

namespace CryptoConsumeAPI
{

    public static class Processor
    {
        public static async Task<string> Start(string name = "", string currency = "USD", string exchange = "", string pair = "", string api = "")
        {
            var tokens = await Process(name, currency, exchange, pair, api);
            return tokens;
        }
        public static async Task<string> Process(string coin = null, string currency = "USD", string exchange = "", string pair = "", string api = "")
        {
            string result = "";
            if (!String.IsNullOrEmpty(coin))
            {
                string url = $"{api}/{pair}";
                object json = await HTTPClientWrapper<dynamic>.Get(url);
                var results = Converter.Convert(json, exchange);
                var price = results.Item1;
                var q = results.Item2;
                result = JsonGenerator.Generate(json, price, q, coin, currency, exchange, pair, api);
            }
            return result;
        }
    }
}