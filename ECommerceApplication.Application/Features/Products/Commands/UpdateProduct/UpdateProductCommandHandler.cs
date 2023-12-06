using ECommerceApplication.Application.Contracts;
using ECommerceApplication.Application.Features.Products.Queries;
using ECommerceApplication.Application.Models;
using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECommerceApplication.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommandResponse>
    {
        private readonly IProductRepository productRepository;
        private readonly IEmailService emailService;
        private readonly ILogger<UpdateProductCommandHandler> logger;

        public UpdateProductCommandHandler(IProductRepository repository, IEmailService emailService, ILogger<UpdateProductCommandHandler> logger)
        {
            this.productRepository = repository;
            this.emailService = emailService;
            this.logger = logger;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new UpdateProductCommandResponse
                {
                    Success = false,
                    ValidationsErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var @event = Product.Create(request.ProductName, request.Price);
            if (@event.IsSuccess)
            {
                @event.Value.AttachCategory(request.CategoryId);

#pragma warning disable CS8604 // Possible null reference argument.
                @event.Value.AttachDescription(request.Description);
#pragma warning restore CS8604 // Possible null reference argument.


#pragma warning disable CS8604 // Possible null reference argument.
                @event.Value.AttachImageUrl(request.ImageUrl);
#pragma warning restore CS8604 // Possible null reference argument.

#pragma warning disable CS8604 // Possible null reference argument.
                //@event.Value.AttachManufacturer(request.ManufacturerId);
#pragma warning restore CS8604 // Possible null reference argument.

                var result = productRepository.AddAsync(@event.Value);
                var email = new Mail
                {
                    Body = $"A new event with name:{@event.Value.ProductName} and price: {@event.Value.Price} has been created",
                    // don't forget to change the email address
                    To = "_REMOVED",
                    Subject = "New Product created",
                };

                try
                {
                    await emailService.SendEmailAsync(email);
                }
                catch (Exception e)
                {
                    logger.LogError(e, "Email sending failed");
                    return new UpdateProductCommandResponse
                    {
                        Success = false,
                        ValidationsErrors = new List<string> { "Email sending failed" }
                    };
                }

                return new UpdateProductCommandResponse
                {
                    Success = true,
                    Product = new ProductDto
                    {
                        ProductId = @event.Value.ProductId,
                        ProductName = @event.Value.ProductName,
                        Price = @event.Value.Price,
                        Description = @event.Value.Description,
                        ImageUrl = @event.Value.ImageUrl,
                        Category = new CategoryDto
                        {
                            CategoryId = @event.Value.CategoryId,
                        }

                    }
                };


            }

            return new UpdateProductCommandResponse
            {
                Success = false,
                ValidationsErrors = new List<string> { @event.Error }
            };
        }
    }
}
