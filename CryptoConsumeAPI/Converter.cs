using System.Collections.Generic;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using CryptoConsumeAPI.Models.ExchangeConvertors;
using JsonEasyNavigation;
using Newtonsoft.Json;
namespace CryptoConsumeAPI.Controllers
{
    public class Converter
    {
        static JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            Error = (sender, error) => error.ErrorContext.Handled = true
        };

        private static (decimal, int) ConvertBinance(object json)
        {
            decimal price = 0;
            var binance = JsonConvert.DeserializeObject<Binance>(json.ToString(), settings);
            if (binance is not null) { price = binance.Price; }
            return (price, 0);
        }

        private static (decimal, int) ConvertKraken(object json)
        {
            var jsonDocument = JsonDocument.Parse(json.ToString());
            var nav = jsonDocument.ToNavigation();
            var result = nav["result"];

            var crypto = JsonConvert.DeserializeObject<Result>(result.JsonElement.ToString(), settings);

            decimal price = 0;
            if (crypto.Crypto is not null)
            {
                foreach (var item in crypto.Crypto)
                {
                    nav = item.Value.ToNavigation();
                    price = Decimal.Parse(nav["a"][0].JsonElement.ToString());
                }
            }

            return (price, 0);
        }

        private static dynamic ConvertCoinbase(object json)
        {
            decimal price = 0;
            var data = JsonConvert.DeserializeObject<Coinbase>(json.ToString(), settings);

            if (data is not null)
            {
                price = Decimal.Parse(data.Data.Amount);
            }
            return (price, 0);
        }


        private static dynamic ConvertCoinMetro(object json)
        {
            decimal price = 0;
            var coinMetro = JsonConvert.DeserializeObject<Coinmetro>(json.ToString(), settings);

            if (coinMetro.latestPrices is not null)
            {
                price = coinMetro.latestPrices[0].price;
            }

            return (price, 0);
        }

        private static dynamic ConvertCrypto(object json)
        {
            decimal price = 0;
            var crypto = JsonConvert.DeserializeObject<Crypto>(json.ToString(), settings);
            if (crypto.Result.Data is not null)
            {
                price = crypto.Result.Data.k;
            }
            return (price, 0);
        }

        private static dynamic ConvertKucoin(object json)
        {
            decimal price = 0;
            var kucoin = JsonConvert.DeserializeObject<Kucoin>(json.ToString(), settings);
            if (kucoin.Data is not null)
            {
                foreach (var item in kucoin.Data)
                {
                    price = Decimal.Parse(item.Value.ToString());
                }
            }
            return (price, 0);
        }

        private static dynamic ConvertUphold(object json)
        {
            decimal price = 0;
            var uphold = JsonConvert.DeserializeObject<Uphold>(json.ToString(), settings);
            if (uphold is not null)
            {
                price = Decimal.Parse(uphold.Ask);
            }
            return (price, 0);
        }

        private static (decimal, int) ConvertAlpaca(object json)
        {
            decimal price = 0;
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            var alpaca = System.Text.Json.JsonSerializer.Deserialize<Alpaca>(json.ToString(), options);

            if (alpaca.Quotes.Crypto is not null)
            {
                foreach (var item in alpaca.Quotes.Crypto)
                {
                    var nav = item.Value.ToNavigation();
                    price = Decimal.Parse(nav["ap"].JsonElement.ToString());
                }
            }

            return (price, 0);
        }

        public static (decimal, int) Convert(object json, string exchange)
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
                case "uphold":
                    result = ConvertUphold(json);
                    break;
                case "alpaca":
                    result = ConvertAlpaca(json);
                    break;
                default:
                    result = (0, 0);
                    break;
            }
            return result;
        }
    }
}