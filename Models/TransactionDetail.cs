namespace DotnetMarketplace.Models
{
    public class TransactionDetail
    {
        public long Id { get; set; }
        public long TransactionId { get; set; }
        public long Qty { get; set; }
        public double Amount { get; set; }
        public string? Notes { get; set; }
        public long ProductId { get; set; }
        public Product? Product { get; set; }
    }
}