using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace CryptoConsumeAPI.Models.ExchangeConvertors
{
    // [JsonConverter(typeof(JsonConverter))]
    public class Kraken
    {
        public object[] Error { get; set; }
        [JsonPropertyName("result")]
        public Result Result { get; set; }
    }

    public partial class Result
    {
        // get the sub-object from the json object
        [JsonExtensionDataAttribute]
        public Dictionary<string, object> Crypto { get; set; }
    }

    public partial class Crypto
    {
        [JsonPropertyName("a")]
        public string[] Ask { get; set; }
        [JsonPropertyName("b")]
        public string[] Bid { get; set; }
        public string[] C { get; set; }
        public string[] V { get; set; }
        public string[] P { get; set; }
        public long[] T { get; set; }
        public string[] L { get; set; }
        public string[] H { get; set; }
        public string O { get; set; }
    }
}