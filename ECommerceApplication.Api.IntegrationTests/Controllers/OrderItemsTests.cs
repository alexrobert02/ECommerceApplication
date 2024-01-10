using System.Drawing.Printing;
using FluentAssertions;
using ECommerceApplication.API.IntegrationTests.Base;
using ECommerceApplication.Application.Features.Products.Queries;
using ECommerceApplication.Application.Features.Products.Commands.CreateProduct;
using Newtonsoft.Json;
using System.Net.Http.Json;
using ECommerceApplication.App.Services.Responses;
using ECommerceApplication.Application.Features;
using ECommerceApplication.Application.Features.OrderItems;
using ECommerceApplication.Application.Features.OrderItems.Commands.CreateOrderItem;
using Xunit.Abstractions;

namespace ECommerceApplication.API.IntegrationTests.Controllers
{

    public class OrderItemsControllerTests : BaseApplicationContextTests
    {
        private const string RequestUri = "/api/v1/orderitems";
        private const string RequestProductUri = "/api/v1/products";

        [Fact]
        public async Task When_GetAllOrderItemsQueryHandlerIsCalled_Then_Success()
        {
            // Arrange && Act
            var response = await Client.GetAsync(RequestUri);

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<OrderItemDto>>(responseString);
            // Assert
            result?.Count.Should().Be(2);
        }
        
        [Fact]
        public async Task When_PostOrderItemsCommandHandlerIsCalledWithRightParameters_Then_TheEntityCreatedShouldBeReturned()
        {
            // Arrange and Act
            var responseProduct = await Client.GetAsync(RequestProductUri);

            responseProduct.EnsureSuccessStatusCode();
            var responseProductString = await responseProduct.Content.ReadAsStringAsync();
            var resultProduct = JsonConvert.DeserializeObject<ApiResponse<List<ProductDto>>>(responseProductString);

            if (resultProduct.Data == null)
            {
                // Handle the error appropriately.
                // For example, you might want to throw an informative exception,
                // log an error message, or simply return.
                throw new Exception("Product data is not available or insufficient.");
            }

            var orderItem = new CreateOrderItemCommand
            {
                ProductId = resultProduct.Data[0].ProductId,
                Quantity = 4,
                PricePerUnit = 200
            };

            // Act
            var response = await Client.PostAsJsonAsync(RequestUri, orderItem);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponse<OrderItemDto>>(responseString);
            result?.Should().NotBeNull();
            result?.Data?.ProductId.Should().Be(orderItem.ProductId);
            result?.Data?.Quantity.Should().Be(orderItem.Quantity);
            result?.Data?.PricePerUnit.Should().Be(orderItem.PricePerUnit);
        }



    }
}
