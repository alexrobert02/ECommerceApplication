using FluentAssertions;
using ECommerceApplication.API.IntegrationTests.Base;
using ECommerceApplication.Application.Features.Addresses.Queries;
using ECommerceApplication.Application.Features.Addresses.Commands.CreateAddress;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using ECommerceApplication.App.Services;
using ECommerceApplication.App.Services.Responses;

namespace ECommerceApplication.API.IntegrationTests.Controllers
{

    public class AddressesControllerTests : BaseApplicationContextTests
    {
        private const string RequestUri = "/api/v1/addresses";

        [Fact]
        public async Task When_GetAllAddressesQueryHandlerIsCalled_Then_Success()
        {
            // Arrange && Act
            var response = await Client.GetAsync(RequestUri);

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponse<List<AddressDto>>>(responseString);
            // Assert
            result?.Data?.Count.Should().Be(2);
        }

        [Fact]
        public async Task When_PostAddressCommandHandlerIsCalledWithRightParameters_Then_TheEntityCreatedShouldBeReturned()
        {
            // Arrange
            var address = new CreateAddressCommand
            {
                Street = "Test Street",
                City = "Test City",
                State = "Test State",
                PostalCode = "Test PostalCode",
                IsDefault = true
            };
            // Act
            var response = await Client.PostAsJsonAsync(RequestUri, address);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponse<AddressDto>>(responseString);
            result?.Should().NotBeNull();
            result?.Data?.Street.Should().Be(address.Street);
        }

    }
}
