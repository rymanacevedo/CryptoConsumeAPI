
namespace CryptoConsumeAPI.Models
{
    public class Asset
    {
        public Asset(string id, string name, object description, decimal price, decimal quantity, string exchange, string currency, string api)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            Exchange = exchange;
            Currency = currency;
            Api = api;
        }
        public string Id { get; }
        public string Name { get; }
        public object Description { get; }
        public decimal Price { get; }
        public decimal Quantity { get; }
        public string Exchange { get; }
        public string Currency { get; }
        public string Api { get; }
    }
}