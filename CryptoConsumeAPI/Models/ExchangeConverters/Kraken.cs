using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace CryptoConsumeAPI.Models.ExchangeConvertors
{
    public class Kraken
    {
        public object[] Error { get; set; }
        public Result Result { get; set; }
    }

    public partial class Result
    { 
        [JsonExtensionDataAttribute]
        public IDictionary<string, JsonElement> Crypto { get; set; }
    }
}