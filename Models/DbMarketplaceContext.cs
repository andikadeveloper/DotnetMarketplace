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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Celana Panjang", Price = 50_000, Image = "https://images.tokopedia.net/img/cache/900/VqbcmM/2023/2/26/3a8909b4-fd5e-429d-a722-1695fbb28f1c.jpg" },
                new Product { Id = 2, Name = "Kaos Oblong", Price = 20_000, Image = "https://images.tokopedia.net/img/cache/900/VqbcmM/2022/11/5/9fa4f2fb-d380-44aa-aa6a-b1c809b2bc27.jpg" },
                new Product { Id = 3, Name = "Topi Hitam", Price = 10_000, Image = "https://images.tokopedia.net/img/cache/900/VqbcmM/2022/8/14/635bc911-24a0-46ec-a1dd-a0b3c193713a.jpg" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Andika", LastName = "Developer" }
            );
        }
    }
}