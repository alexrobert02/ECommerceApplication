using ECommerceApplication.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ECommerceApplication.Domain.Tests
{
    public class RewardTests
    {
        [Fact]
        public void When_CreateRewardIsCalled_And_RewardInfoAreValid_Then_SuccessIsReturned()
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
        public void When_CreateRewardIsCalled_And_UserIdIsDefault_Then_FailureIsReturned()
        {
            Guid userId = default;
            decimal rewardValue = 10;
            DateTime expiryDate = DateTime.UtcNow.AddDays(30);
            // Arrange && Act
            var result = Reward.Create(userId, rewardValue, expiryDate);
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_CreateRewardIsCalled_And_RewardValueIsSmallerThanZero_Then_FailureIsReturned()
        {
            Guid userId = Guid.NewGuid();
            decimal rewardValue = -19;
            DateTime expiryDate = DateTime.UtcNow.AddDays(30);
            // Arrange && Act
            var result = Reward.Create(userId, rewardValue, expiryDate);
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_CreateRewardIsCalled_And_RewardValueIsZero_Then_FailureIsReturned()
        {
            Guid userId = Guid.NewGuid();
            decimal rewardValue = 0;
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
            DateTime expiryDate = DateTime.UtcNow.AddDays(-5);
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
            var result = Reward.Create(userId, rewardValue, expiryDate);
            // Arrange && Act
            result.Value.IsRewardValid();
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
            var result = Reward.Create(userId, rewardValue, expiryDate);
            decimal increaseValue = 10;
            // Arrange && Act
            result.Value.IncreaseReward(increaseValue);
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void When_IncreaseRewardValueIsCalled_And_RewardValueIsNotIncreased_Then_FailureIsReturned()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            decimal rewardValue = 10;
            DateTime expiryDate = DateTime.UtcNow.AddDays(1);
            var result = Reward.Create(userId, rewardValue, expiryDate);
            decimal increaseValue = -10;
            // Act & Assert
            result.Invoking(r => r.Value.IncreaseReward(increaseValue))
                  .Should().Throw<ArgumentException>().WithMessage("Increase value cannot be less than or equal to zero."); 

        }

        [Fact]
        public void When_DecreaseRewardValueIsCalled_And_RewardValueIsDecreased_Then_SuccessIsReturned()
        {
            Guid userId = Guid.NewGuid();
            decimal rewardValue = 10;
            DateTime expiryDate = DateTime.UtcNow.AddDays(1);
            // Arrange && Act
            var result = Reward.Create(userId, rewardValue, expiryDate);
            result.Value.DecreaseReward(5);
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void When_DecreaseRewardValueIsCalled_And_RewardValueIsSmallerThanZero_Then_FailureIsReturned()
        {
            Guid userId = Guid.NewGuid();
            decimal rewardValue = 10;
            DateTime expiryDate = DateTime.UtcNow.AddDays(1);
            // Arrange && Act
            var result = Reward.Create(userId, rewardValue, expiryDate);
            // Act & Assert
            result.Invoking(r => r.Value.DecreaseReward(-20))
                  .Should().Throw<ArgumentException>().WithMessage("Decrease value cannot be less than or equal to zero.");
        }

        [Fact]
        public void When_UpdateRewardIsCalled_And_RewardValueIsUpdated_Then_SuccessIsReturned()
        {
            Guid userId = Guid.NewGuid();
            decimal rewardValue = 10;
            DateTime expiryDate = DateTime.UtcNow.AddDays(1);
            // Arrange && Act
            var result = Reward.Create(userId, rewardValue, expiryDate);
            result.Value.UpdateRewardDate(DateTime.UtcNow.AddDays(10));
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
            // Act & Assert
            result.Invoking(r => r.Value.UpdateRewardDate(DateTime.UtcNow.AddDays(-10)))
                  .Should().Throw<ArgumentException>().WithMessage("Reward date cannot be less than or equal to current date.");
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
