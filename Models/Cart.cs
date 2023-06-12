namespace DotnetMarketplace.Models
{
    public class Cart
    {
        public long Id { get; set; }
        public long Qty { get; set; }
        public double Amount { get; set; }
        public string? Notes { get; set; }
        public long ProductId { get; set; }
        public Product? Product { get; set; }
        public long UserId { get; set; }
        public User? User { get; set; }
    }
}