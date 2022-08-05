namespace CryptoConsumeAPI.Models.ExchangeConvertors
{
    public class Coinbase
    {
        public CoinbaseData Data { get; set; }
    }

    public class CoinbaseData 
    {
        public string Base { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
    }
}