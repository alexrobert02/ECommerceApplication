using ECommerceApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ECommergeApplicationContext : DbContext
    {
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ECommergeApplicationDB;Username=postgres;Password=AnaMaria");
        }
    }
}
