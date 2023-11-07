using ECommerceApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ECommergeApplicationContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ECommergeApplicationDB;Username=postgres;Password=password");
        }
    }
}