using ECommerceApplication.Domain.Common;

namespace ECommerceApplication.Domain.Entities
{
    public class Reward
    {
        public Reward(Guid userId, decimal? rewardValue, DateTime? rewardDate)
        {
            RewardId = Guid.NewGuid();
            UserId = userId;
            RewardValue = rewardValue;
            RewardDate = rewardDate;
        }

        public Guid RewardId { get; set; }
        public Guid UserId { get; set; }

        public decimal? RewardValue { get; set; }

        public DateTime? RewardDate { get; set; }
        public List<Discount> Discounts { get; set; }

        public static Result<Reward> Create(Guid userId, decimal rewardValue, DateTime rewardDate)
        {
            if (userId == default)
            {
                return Result<Reward>.Failure("User id is required.");
            }
            if (rewardDate == default)
            {
                return Result<Reward>.Failure("Reward date is required.");
            }
            if (rewardValue == default)
            {
                return Result<Reward>.Failure("Reward value is required.");
            }
            return Result<Reward>.Success(new Reward(userId, rewardValue, rewardDate));

        }

        public bool IsRewardValid()
        {
            if (RewardDate >= DateTime.Now)
            {
                return true;
            }
            return false;
        }

        public void IncreaseReward(decimal rewardValue)
        {
            if (rewardValue == default)
            {
                throw new ArgumentNullException(nameof(rewardValue), "Reward value cannot be null.");
            }
            if (rewardValue <= 0)
            {
                throw new ArgumentException("Reward value cannot be less than or equal to zero.", nameof(rewardValue));
            }
            if (IsRewardValid())
            {
                RewardValue += rewardValue;
            }
        }

        public void DecreaseReward(decimal rewardValue)
        {
            if (rewardValue == default)
            {
                throw new ArgumentNullException(nameof(rewardValue), "Reward value cannot be null.");
            }
            if (rewardValue <= 0)
            {
                throw new ArgumentException("Reward value cannot be less than or equal to zero.", nameof(rewardValue));
            }
            if (IsRewardValid())
            {
                RewardValue -= rewardValue;
            }
        }

        public void UpdateRewardDate(DateTime rewardDate)
        {
            if (rewardDate == default)
            {
                throw new ArgumentNullException(nameof(rewardDate), "Reward date cannot be null.");
            }
            RewardDate = rewardDate;
        }

        public void AddDiscount(Discount discount)
        {
            if (discount == null)
            {
                throw new ArgumentNullException(nameof(discount), "Discount cannot be null.");
            }

            Discounts.Add(discount);
        }

    }
}
