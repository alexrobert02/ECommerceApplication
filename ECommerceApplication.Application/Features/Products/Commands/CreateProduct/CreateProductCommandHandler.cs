using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;
using MediatR;

namespace ECommerceApplication.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IProductRepository repository;

        public CreateProductCommandHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new CreateProductCommandResponse
                {
                    Success = false,
                    ValidationsErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var product = Product.Create(request.ProductName, request.Price, request.Manufacturer);
            if (!product.IsSuccess)
            {
                return new CreateProductCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { product.Error }
                };
            }

            await repository.AddAsync(product.Value);

            return new CreateProductCommandResponse
            {
                Success = true,
                Product = new CreateProductDto
                {
                    ProductId = product.Value.ProductId,
                    ProductName = product.Value.ProductName,
                    Price = product.Value.Price,
                    Manufacturer = product.Value.Manufacturer,
                }
            };
        }
    }
}
