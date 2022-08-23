using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace CryptoConsumeAPI.Models.ExchangeConvertors
{
    public class Kucoin
    {
        public string Code { get; set; }
        [JsonExtensionData]
        public JObject Data { get; set; }
    }
}