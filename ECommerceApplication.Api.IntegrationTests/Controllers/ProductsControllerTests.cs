using System.ComponentModel;
using FluentAssertions;
using ECommerceApplication.API.IntegrationTests.Base;
using ECommerceApplication.Application.Features.Products.Queries;
using ECommerceApplication.Application.Features.Products.Commands.CreateProduct;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using ECommerceApplication.App.Services;
using ECommerceApplication.App.Services.Responses;
using ECommerceApplication.Application.Features;
using ECommerceApplication.Application.Features.Categories.Commands.CreateCategory;

namespace ECommerceApplication.API.IntegrationTests.Controllers
{

    public class ProductsControllerTests : BaseApplicationContextTests
    {
        private const string RequestUri = "/api/v1/products";

        [Fact]
        public async Task When_GetAllProductsQueryHandlerIsCalled_Then_Success()
        {
            // Arrange && Act
            var response = await Client.GetAsync(RequestUri);

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponse<List<ProductDto>>>(responseString);
            // Assert
            result?.Data?.Count.Should().Be(2);
        }

        [Fact]
        public async Task When_PostProductsCommandHandlerIsCalledWithRightParameters_Then_TheEntityCreatedShouldBeReturned()
        {
            // Arrange and Act

            var responseCategory = await Client.GetAsync("/api/v1/categories");
            responseCategory.EnsureSuccessStatusCode();
            var responseCategoryString = await responseCategory.Content.ReadAsStringAsync();
            var resultCategory = JsonConvert.DeserializeObject<List<CategoryDto>>(responseCategoryString);

            var product = new CreateProductCommand
            {
                ProductName = "ProductName",
                Price = 10,
                Description = "Description",
                ImageUrl = "ImageUrl",
                CategoryId = resultCategory[1].CategoryId
            };

            // Act
            var response = await Client.PostAsJsonAsync(RequestUri, product);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponse<ProductDto>>(responseString);
            result?.Should().NotBeNull();
            result?.Data?.ProductName.Should().Be(product.ProductName);
            result?.Data?.Price.Should().Be(product.Price);
            result?.Data?.Description.Should().Be(product.Description);
            result?.Data?.ImageUrl.Should().Be(product.ImageUrl);
            result?.Data?.Category.CategoryId.Should().Be(product.CategoryId);
        }

    }
}
