using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using CryptoConsumeAPI.Models;

namespace CryptoConsumeAPI
{
    [JsonSerializable(typeof(Asset), GenerationMode = JsonSourceGenerationMode.Metadata)]
    internal partial class JsonContext : JsonSerializerContext
    {
    }
}