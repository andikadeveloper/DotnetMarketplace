using Microsoft.EntityFrameworkCore;

namespace DotnetMarketplace.Models
{
    public class DbMarketplaceContext : DbContext
    {
        public DbMarketplaceContext(DbContextOptions<DbMarketplaceContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;
        public DbSet<TransactionDetail> TransactionDetails { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
    }
}