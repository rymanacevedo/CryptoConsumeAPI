using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CryptoConsumeAPI.Models.ExchangeConvertors
{
    public class Alpaca
    {
        public Quotes Quotes { get; set; }
    }

    public partial class Quotes
    {
        [JsonExtensionDataAttribute]
        public IDictionary<string, JsonElement> Crypto { get; set; }
    }
}