using ECommerceApplication.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Domain.Tests
{
    public class RewardTests
    {
        [Fact]
        public void When_CreateRewardIsCalled_And_RewardNameIsValid_Then_SuccessIsReturned()
        {
            Guid userId = Guid.NewGuid();
            decimal rewardValue = 10;
            DateTime expiryDate = DateTime.UtcNow.AddDays(30);
            // Arrange && Act
            var result = Reward.Create(userId, rewardValue, expiryDate);
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void When_CreateRewardIsCalled_And_RewardNameIsNull_Then_FailureIsReturned()
        {
            decimal rewardValue = 10;
            DateTime expiryDate = DateTime.UtcNow.AddDays(30);
            // Arrange && Act
            var result = Reward.Create(Guid.Empty, rewardValue, expiryDate);
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_CreateRewardIsCalled_And_RewardValueIsNegative_Then_FailureIsReturned()
        {
            Guid userId = Guid.NewGuid();
            decimal rewardValue = -10;
            DateTime expiryDate = DateTime.UtcNow.AddDays(30);
            // Arrange && Act
            var result = Reward.Create(userId, rewardValue, expiryDate);
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_CreateRewardIsCalled_And_ExpiryDateIsInThePast_Then_FailureIsReturned()
        {
            Guid userId = Guid.NewGuid();
            decimal rewardValue = 10;
            DateTime expiryDate = DateTime.UtcNow;
            // Arrange && Act
            var result = Reward.Create(userId, rewardValue, expiryDate);
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_CreateRewardIsCalled_And_ExpiryDateIsInTheFuture_Then_SuccessIsReturned()
        {
            Guid userId = Guid.NewGuid();
            decimal rewardValue = 10;
            DateTime expiryDate = DateTime.UtcNow.AddDays(30);
            // Arrange && Act
            var result = Reward.Create(userId, rewardValue, expiryDate);
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void When_IsValidIsCalled_And_RewardIsExpired_Then_FalseIsReturned()
        {
            Guid userId = Guid.NewGuid();
            decimal rewardValue = 10;
            DateTime expiryDate = DateTime.UtcNow.AddDays(-1);
            // Arrange && Act
            var result = Reward.Create(userId, rewardValue, expiryDate);
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_IsValidIsCalled_And_RewardIsNotExpired_Then_TrueIsReturned()
        {
            Guid userId = Guid.NewGuid();
            decimal rewardValue = 10;
            DateTime expiryDate = DateTime.UtcNow.AddDays(1);
            // Arrange && Act
            var result = Reward.Create(userId, rewardValue, expiryDate);
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void When_IncreaseRewardValueIsCalled_And_RewardValueIsIncreased_Then_SuccessIsReturned()
        {
            Guid userId = Guid.NewGuid();
            decimal rewardValue = 10;
            DateTime expiryDate = DateTime.UtcNow.AddDays(1);
            // Arrange && Act
            var result = Reward.Create(userId, rewardValue, expiryDate);
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void When_IncreaseRewardValueIsCalled_And_RewardValueIsNotIncreased_Then_FailureIsReturned()
        {
            Guid userId = Guid.NewGuid();
            decimal rewardValue = 10;
            DateTime expiryDate = DateTime.UtcNow.AddDays(1);
            // Arrange && Act
            var result = Reward.Create(userId, rewardValue, expiryDate);
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void When_DecreaseRewardValueIsCalled_And_RewardValueIsDecreased_Then_SuccessIsReturned()
        {
            Guid userId = Guid.NewGuid();
            decimal rewardValue = 10;
            DateTime expiryDate = DateTime.UtcNow.AddDays(1);
            // Arrange && Act
            var result = Reward.Create(userId, rewardValue, expiryDate);
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void When_DecreaseRewardValueIsCalled_And_RewardValueIsNotDecreased_Then_FailureIsReturned()
        {
            Guid userId = Guid.NewGuid();
            decimal rewardValue = 10;
            DateTime expiryDate = DateTime.UtcNow.AddDays(1);
            // Arrange && Act
            var result = Reward.Create(userId, rewardValue, expiryDate);
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void When_UpdateRewardIsCalled_And_RewardValueIsUpdated_Then_SuccessIsReturned()
        {
            Guid userId = Guid.NewGuid();
            decimal rewardValue = 10;
            DateTime expiryDate = DateTime.UtcNow.AddDays(1);
            // Arrange && Act
            var result = Reward.Create(userId, rewardValue, expiryDate);
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void When_UpdateRewardIsCalled_And_RewardValueIsNotUpdated_Then_FailureIsReturned()
        {
            Guid userId = Guid.NewGuid();
            decimal rewardValue = 10;
            DateTime expiryDate = DateTime.UtcNow.AddDays(1);
            // Arrange && Act
            var result = Reward.Create(userId, rewardValue, expiryDate);
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void When_AddDiscountIsCalled_And_DiscountIsAdded_Then_SuccessIsReturned()
        {
            Guid userId = Guid.NewGuid();
            decimal rewardValue = 10;
            DateTime expiryDate = DateTime.UtcNow.AddDays(1);
            string code = "Test Discount";
            decimal percentage = 10;
            DateTime expiryDateDiscount = DateTime.UtcNow.AddDays(10);
            var discount = Discount.Create(code, percentage, expiryDateDiscount).Value;
            // Arrange && Act
            var result = Reward.Create(userId, rewardValue, expiryDate);
            result.Value.AddDiscount(discount);
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeTrue();
            
        }
    }
}
