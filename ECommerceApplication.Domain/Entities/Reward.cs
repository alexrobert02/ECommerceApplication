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
            Discounts = new List<Discount>();
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
            if (rewardDate == default || rewardDate<DateTime.UtcNow)
            {
                return Result<Reward>.Failure("Reward date is required.");
            }
            if (rewardValue == default || rewardValue<0)
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
            
            if (rewardValue <= 0)
            {
                throw new ArgumentException("Increase value cannot be less than or equal to zero.");
            }
            if (IsRewardValid())
            {
                RewardValue += rewardValue;
            }
        }

        public void DecreaseReward(decimal rewardValue)
        {
            if (rewardValue < 0)
            {
                throw new ArgumentException("Decrease value cannot be less than or equal to zero.");
            }
            if (IsRewardValid())
            {
                RewardValue -= rewardValue;
            }
        }

        public void UpdateRewardDate(DateTime rewardDate)
        {
            if (rewardDate <DateTime.UtcNow)
            {
                throw new ArgumentException("Reward date cannot be less than or equal to current date.");
            }
            RewardDate = rewardDate;
        }

        public void AddDiscount(Discount discount)
        {
            if (discount == null)
            {
                throw new ArgumentNullException("Discount cannot be null.");
            }

            Discounts.Add(discount);
        }

    }
}
