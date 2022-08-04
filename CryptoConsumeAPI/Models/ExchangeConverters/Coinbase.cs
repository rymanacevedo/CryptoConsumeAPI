namespace CryptoConsumeAPI.Models.ExchangeConvertors
{
    public class Coinbase
    {
        public Data Data { get; set; }
    }

    public class Data 
    {
        public string Base { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
    }
}