using Microsoft.EntityFrameworkCore;

namespace DotnetMarketplace.Models
{
    public class DbMarketplaceContext : DbContext
    {
        public DbMarketplaceContext(DbContextOptions<DbMarketplaceContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; } = null!;
    }
}