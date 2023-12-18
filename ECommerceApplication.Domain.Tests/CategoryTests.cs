using ECommerceApplication.Domain.Entities;
using FluentAssertions;

namespace ECommerceApplication.Domain.Tests
{
    public class CategoryTests
    {
        [Fact]
        public void When_CreateCategoryIsCalled_And_CategoryNameIsValid_Then_SuccessIsReturned()
        {
            // Arrange && Act
            var result = Category.Create("Test Category");
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void When_CreateCategoryIsCalled_And_CategoryNameIsNull_Then_FailureIsReturned()
        {
            // Arrange && Act
            var result = Category.Create(null);
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeFalse();
        }
    }
}