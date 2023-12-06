using ECommerceApplication.Application.Features.Categories.Commands.UpdateCategory;
using ECommerceApplication.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.Features.OrderItems.Commands.UpdateOrderItem
{
    public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand, UpdateOrderItemCommandResponse>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProductRepository _productRepository;
        public UpdateOrderItemCommandHandler(IOrderItemRepository orderItemRepository, IProductRepository productRepository)
        {
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
        }

        public async Task<UpdateOrderItemCommandResponse> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOrderItemCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validatorResult.IsValid)
            {
                return new UpdateOrderItemCommandResponse
                {
                    Success = false,
                    ValidationsErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }
            var orderItem = await _orderItemRepository.FindByIdAsync(request.OrderItemId);
            if (orderItem == null)
                return new UpdateOrderItemCommandResponse
                {
                    Success = false,
                    ValidationsErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            var product = await _productRepository.FindByIdAsync(request.ProductId);
            if (product == null)
                return new UpdateOrderItemCommandResponse
                {
                    Success = false,
                    ValidationsErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            var updateResult = orderItem.Value.UpdatePricePerUnit(request.PricePerUnit);
            if (!updateResult.IsSuccess)
            {
                return new UpdateOrderItemCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { updateResult.Error }
                };
            }
            updateResult = orderItem.Value.UpdateQuantity(request.Quantity);
            if (!updateResult.IsSuccess)
            {
                return new UpdateOrderItemCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { updateResult.Error }
                };
            }
            await _orderItemRepository.UpdateAsync(orderItem.Value);
            return new UpdateOrderItemCommandResponse
            {
                Success = true,
                OrderItem = new UpdateOrderItemDto
                {
                    OrderItemId = orderItem.Value.OrderItemId,
                    ProductId = orderItem.Value.ProductId,
                    Quantity = orderItem.Value.Quantity,
                    PricePerUnit = orderItem.Value.PricePerUnit
                }
            };
        }
    }
}