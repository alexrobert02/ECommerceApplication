using ECommerceApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ECommerceApplicationContext : DbContext
    {
        public ECommerceApplicationContext(
            DbContextOptions<ECommerceApplicationContext> options) :
            base(options)
        {

        }

        public DbSet<Category> Categories{ get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
