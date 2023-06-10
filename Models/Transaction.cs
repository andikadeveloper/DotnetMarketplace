namespace DotnetMarketplace.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long ProductId { get; set; }
        public Product? Product { get; set; }
        public long UserId { get; set; }
        public User? User { get; set; }
        public long Qty { get; set; }
        public long Bill { get; set; }
    }
}