
using System;
using System.Text.Json;
using System.Threading.Tasks;
using CryptoConsumeAPI.Controllers;
using CryptoConsumeAPI.Models;

public static class Processor {
    public static async Task<string> Start(string name = "", string currency = "USD", string exchange = "", string pair = "", string api = "") {
        var tokens = await Process(name, currency, exchange, pair, api);
        return tokens.GetRawText();
    }
    public static async Task<JsonElement> Process(string coin = null, string currency = "USD", string exchange = "", string pair = "", string api = "")
    {
        JsonElement result = new JsonElement();

        if (!String.IsNullOrEmpty(coin))
        {
            string url = $"{api}/{pair}";
            result = await HTTPClientWrapper<dynamic>.Get(url);
        }
        return result;
    }
}