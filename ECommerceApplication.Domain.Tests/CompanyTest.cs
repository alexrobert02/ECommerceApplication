using ECommerceApplication.Domain.Entities;
using FluentAssertions;

// Import necessary namespaces

namespace ECommerceApplication.Domain.Tests
{
    public class CompanyTests
    {
        [Fact]
        public void When_CreateCompanyIsCalled_WithValidParameters_Then_SuccessIsReturned()
        {
            // Arrange && Act
            var result = Company.Create("Test Company", "Company Address", "123456789", "test@example.com");

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.CompanyId.Should().NotBe(Guid.Empty);
        }

        [Fact]
        public void When_CreateCompanyIsCalled_WithInvalidName_Then_FailureIsReturned()
        {
            // Arrange && Act
            var result = Company.Create("", "Company Address", "123456789", "test@example.com");

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Contain("Company Name is required.");
        }

        [Fact]
        public void When_CreateCompanyIsCalled_WithInvalidAddress_Then_FailureIsReturned()
        {
            // Arrange && Act
            var result = Company.Create("Test Company", "", "123456789", "test@example.com");

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Contain("Company Address is required.");
        }

        [Fact]
        public void When_CreateCompanyIsCalled_WithInvalidPhoneNumber_Then_FailureIsReturned()
        {
            // Arrange && Act
            var result = Company.Create("Test Company", "Company Address", "", "test@example.com");

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Contain("Phone number is required.");
        }

        [Fact]
        public void When_CreateCompanyIsCalled_WithInvalidEmail_Then_FailureIsReturned()
        {
            // Arrange && Act
            var result = Company.Create("Test Company", "Company Address", "123456789", "");

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Contain("Email is required.");
        }

        [Fact]
        public void When_UpdateCompanyIsCalled_WithValidParameters_Then_CompanyIsUpdatedSuccessfully()
        {
            // Arrange
            var company = Company.Create("Initial Company", "Initial Address", "987654321", "initial@example.com").Value;

            // Act
            company.Update("Updated Company", "Updated Address", "123456789", "updated@example.com");

            // Assert
            company.CompanyName.Should().Be("Updated Company");
            company.CompanyAddress.Should().Be("Updated Address");
            company.PhoneNumber.Should().Be("123456789");
            company.Email.Should().Be("updated@example.com");
        }

        [Fact]
        public void When_AddProductIsCalled_Then_ProductIsAddedToCompany()
        {
            // Arrange
            var company = Company.Create("Test Company", "Company Address", "123456789", "test@example.com").Value;
            var product = Product.Create("Product1", 10);

            // Act
            company.AddProduct(product.Value);

            // Assert
            company.Products.Should().Contain(product.Value);
        }
    }
}

