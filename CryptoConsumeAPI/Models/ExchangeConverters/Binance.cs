using System.Text.Json.Serialization;
namespace CryptoConsumeAPI.Models.ExchangeConvertors
{
    public class Binance
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}