namespace CryptoConsumeAPI.Models.ExchangeConvertors
{
    public class Crypto
    {
        public int Code { get; set; }
        public string Method { get; set; }
        public Result Result { get; set; }
    }

    public partial class Result
    {
        public Data Data { get; set; }
    }

    public partial class Data
    {
        public decimal b { get; set; }
        public decimal k { get; set; }
        public decimal a { get; set; }
        public long t { get; set; }
        public decimal v { get; set; }
        public decimal vv { get; set; }
        public decimal h { get; set; }
    }
}