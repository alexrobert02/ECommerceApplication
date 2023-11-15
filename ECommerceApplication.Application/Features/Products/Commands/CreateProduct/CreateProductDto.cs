using ECommerceApplication.Domain.Entities;

namespace ECommerceApplication.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductDto
    {
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
        public Manufacturer? Manufacturer { get; set; }
    }
}

