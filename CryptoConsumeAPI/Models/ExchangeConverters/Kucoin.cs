using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CryptoConsumeAPI.Models.ExchangeConvertors
{
    public class Kucoin
    {
        public string Code { get; set; }
        public KucoinData Data { get; set; }
    }

    public class KucoinData
    {
        [JsonExtensionDataAttribute]
        public IDictionary<string, JsonElement> Price { get; set; }
    }
}