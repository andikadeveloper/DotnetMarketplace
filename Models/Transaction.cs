namespace DotnetMarketplace.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long UserId { get; set; }
        public User? User { get; set; }
        public double Bill { get; set; }
        public string? PaymentProvider { get; set; }
        public string? ShippingProvider { get; set; }
        public ICollection<TransactionDetail> TransactionDetails { get; } = new List<TransactionDetail>();
    }
}