using System.Collections.Generic;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using CryptoConsumeAPI.Models.ExchangeConvertors;
using JsonEasyNavigation;

namespace CryptoConsumeAPI.Controllers
{
    public class Converter
    {
        private static decimal ConvertBinance(object json)
        {
            var options = new JsonSerializerOptions()
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString
            };

            var binance = JsonSerializer.Deserialize<Binance>(json.ToString(), options);
            return binance.Price;
        }

        private static dynamic ConvertKraken(object json)
        {
            var options = new JsonSerializerOptions()
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString |
                JsonNumberHandling.WriteAsString,
                PropertyNameCaseInsensitive = true
            };

            var jsonDocument = JsonDocument.Parse(json.ToString());
            var nav = jsonDocument.ToNavigation();
            var result = nav["result"];

            var crypto = JsonSerializer.Deserialize<Result>(result.JsonElement.ToString(), options);
            decimal price = 0;
            foreach (var item in crypto.Crypto)
            {
                nav = item.Value.ToNavigation();
                price = Decimal.Parse(nav["a"][0].JsonElement.ToString());
            }

            return price;
        }

        private static dynamic ConvertCoinbase(object json)
        {
            decimal price = 0;
            var options = new JsonSerializerOptions()
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString |
                                 JsonNumberHandling.WriteAsString,
                PropertyNameCaseInsensitive = true
            };
            var data = JsonSerializer.Deserialize<Coinbase>(json.ToString(), options);
            price = Decimal.Parse(data.Data.Amount);
            return price;
        }


        private static dynamic ConvertCoinMetro(object json)
        {
            decimal price = 0;
            var options = new JsonSerializerOptions()
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString
            };

            var coinMetro = JsonSerializer.Deserialize<Coinmetro>(json.ToString(), options);

            price = coinMetro.latestPrices[0].price;

            return price;
        }

        private static dynamic ConvertCrypto(object json)
        {
            decimal price = 0;
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            var crypto = JsonSerializer.Deserialize<Crypto>(json.ToString(), options);
            price = crypto.Result.Data.b;
            return price;
        }

        private static dynamic ConvertKucoin(object json) 
        {
            decimal price = 0;
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            var kucoin = JsonSerializer.Deserialize<Kucoin>(json.ToString(), options);
            foreach (var item in kucoin.Data.Price)
            {
                price = Decimal.Parse(item.Value.ToString());
            }
            return price;
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
                case "kraken":
                    result = ConvertKraken(json);
                    break;
                case "coinbase":
                    result = ConvertCoinbase(json);
                    break;
                case "coinmetro":
                    result = ConvertCoinMetro(json);
                    break;
                case "crypto":
                    result = ConvertCrypto(json);
                    break;
                case "kucoin":
                    result = ConvertKucoin(json);
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }
    }
}