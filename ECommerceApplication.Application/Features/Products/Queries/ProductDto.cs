using ECommerceApplication.Domain.Entities;

namespace ECommerceApplication.Application.Features.Products.Queries
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public Manufacturer? Manufacturer { get; set; } = default!;
    }
}
