namespace CryptoConsumeAPI.Models.ExchangeConvertors
{

    public class Coinmetro
    {
        public LatestPrice[] latestPrices { get; set; }
    }
    public class LatestPrice
    {
        public string pair { get; set; }
        public long timestamp { get; set; }
        public decimal price { get; set; }
        public double qty { get; set; }
        public double ask { get; set; }
        public double bid { get; set; }
    }

    public class SentimentData
    {
        public double sentiment { get; set; }
        public double interest { get; set; }
    }
}
