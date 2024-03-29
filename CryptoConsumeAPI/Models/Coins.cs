﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CryptoConsumeAPI.Models
{
    public class Coins
    {
        [JsonPropertyName("data")]
        public JsonElement Data { get; set; }

        [JsonPropertyName("latestPrices")]
        public JsonElement LatestPrices { get; set; }

        [JsonPropertyName("result")]
        public JsonElement Result { get; set; }

        public static implicit operator JsonElement(Coins v)
        {
            throw new NotImplementedException();
        }
    }

}