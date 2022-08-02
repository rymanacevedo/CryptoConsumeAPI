using System.Text.Json;
using System.Text.Json.Serialization;
using CryptoConsumeAPI.Models.ExchangeConvertors;

namespace CryptoConsumeAPI.Controllers
{
    public class Converter
    {
        private static decimal ConvertBinance(object json)
        {
            var options = new JsonSerializerOptions()
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString |
                JsonNumberHandling.WriteAsString
            };

            var binance = JsonSerializer.Deserialize<Binance>(json.ToString(), options);
            return binance.Price;
        }

        private static dynamic ConvertKraken(object json)
        {
            var options = new JsonSerializerOptions()
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString |
                JsonNumberHandling.WriteAsString
            };

            var kraken = JsonSerializer.Deserialize<Kraken>(json.ToString(), options);
            return kraken.Result.Crypto;
        }
        // converts a json object into a json element based of the exhange
        public static dynamic Convert(object json, string exchange)
        {
            dynamic result = null;
            switch (exchange)
            {
                case "binance":
                    result = ConvertBinance(json);
                    break;
                //         case "bittrex":
                //             result = ConvertBittrex(json);
                //             break;
                //         case "bitfinex":
                //             result = ConvertBitfinex(json);
                //             break;
                //         case "bitstamp":
                //             result = ConvertBitstamp(json);
                //             break;
                //         case "coinbase":
                //             result = ConvertCoinbase(json);
                //             break;-
                //         case "gemini":
                //             result = ConvertGemini(json);
                //             break;
                //         case "hitbtc":
                //             result = ConvertHitbtc(json);
                //             break;
                case "kraken":
                    result = ConvertKraken(json);
                    break;
                //             break;
                //         case "poloniex":
                //             result = ConvertPoloniex(json);
                //             break;
                //         case "yobit":
                //             result = ConvertYobit(json);
                //             break;
                //         case "zaif":
                //             result = ConvertZaif(json);
                //             break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }
    }
}