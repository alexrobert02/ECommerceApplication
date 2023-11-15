using ECommerceApplication.Domain.Entities;
using MediatR;

namespace ECommerceApplication.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductCommandResponse>
    {
        public string ProductName { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public Manufacturer Manufacturer { get; set; } = default!;
    }
}
