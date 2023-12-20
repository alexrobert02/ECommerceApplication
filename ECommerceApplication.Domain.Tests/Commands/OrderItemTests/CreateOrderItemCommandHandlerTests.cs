using Xunit;
using NSubstitute;
using ECommerceApplication.Application.Features.OrderItems.Commands.CreateOrderItem;
using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.Tests.Commands.OrderItemTests
{
    public class CreateOrderItemCommandHandlerTests
    {
        private readonly IOrderItemRepository _repository;
        private readonly IProductRepository _productRepository;
        private readonly CreateOrderItemCommandHandler _handler;

        public CreateOrderItemCommandHandlerTests()
        {
            _repository = Substitute.For<IOrderItemRepository>();
            _productRepository = Substitute.For<IProductRepository>();
            _handler = new CreateOrderItemCommandHandler(_repository, _productRepository);
        }

        [Fact]
        public async Task Handle_InvalidInput_ReturnsFailure()
        {
            var invalidCommand = new CreateOrderItemCommand { ProductId = Guid.Empty, Quantity = 0, PricePerUnit = -1 };
            var response = await _handler.Handle(invalidCommand, new CancellationToken());
            Assert.False(response.Success);
            Assert.NotNull(response.ValidationsErrors);
            Assert.NotEmpty(response.ValidationsErrors);
        }

        [Fact]
        public async Task Handle_ProductDoesNotExist_ReturnsFailure()
        {
            // Arrange
            var validCommand = new CreateOrderItemCommand { ProductId = Guid.NewGuid(), Quantity = 1, PricePerUnit = 10.0M };
            _productRepository.ProductExists(validCommand.ProductId).Returns(false);

            // Act
            var response = await _handler.Handle(validCommand, new CancellationToken());

            // Assert
            Assert.False(response.Success);
            Assert.NotNull(response.ValidationsErrors);
            Assert.Contains("Product with the provided ID does not exist.", response.ValidationsErrors);
        }

        [Fact]
        public async Task Handle_OrderItemCreationFailure_ReturnsFailure()
        {
            // Arrange
            var validCommand = new CreateOrderItemCommand { ProductId = Guid.NewGuid(), Quantity = 1, PricePerUnit = 10.0M };
            _productRepository.ProductExists(validCommand.ProductId).Returns(true);
            var orderItem = OrderItem.Create(validCommand.ProductId, validCommand.Quantity, validCommand.PricePerUnit);
            Assert.True(orderItem.IsSuccess);

            //_repository.AddAsync(Arg.Any<OrderItem>()).Returns(x => { throw new Exception("Database error"); });

            // Act
            var exception = await Assert.ThrowsAsync<Exception>(() => _handler.Handle(validCommand, new CancellationToken()));

            // Assert
            Assert.Equal("Database error", exception.Message);
        }

        [Fact]
        public async Task Handle_ValidInput_ReturnsSuccess()
        {
            // Arrange
            var validCommand = new CreateOrderItemCommand { ProductId = Guid.NewGuid(), Quantity = 1, PricePerUnit = 10.0M };
            _productRepository.ProductExists(validCommand.ProductId).Returns(true);
            _repository.AddAsync(Arg.Any<OrderItem>()).Returns(Task.CompletedTask);

            // Act
            var response = await _handler.Handle(validCommand, new CancellationToken());

            // Assert
            Assert.True(response.Success);
            Assert.NotNull(response.OrderItem);
            Assert.Equal(validCommand.ProductId, response.OrderItem.ProductId);
            Assert.Equal(validCommand.Quantity, response.OrderItem.Quantity);
            Assert.Equal(validCommand.PricePerUnit, response.OrderItem.PricePerUnit);
        }
    }
}
