namespace DotnetMarketplace.Requests
{
    public class CheckoutTransactionRequest
    {
        public ICollection<long> CheckoutDetail { get; set; } = new List<long>();
        public string? PaymentProvider { get; set; }
        public string? ShippingProvider { get; set; }
    }
}