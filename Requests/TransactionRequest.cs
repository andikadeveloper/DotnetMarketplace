namespace DotnetMarketplace.Requests
{
    public class TransactionRequest
    {
        public long ProductId { get; set; }
        public long UserId { get; set; }
        public long Qty { get; set; }
    }
}