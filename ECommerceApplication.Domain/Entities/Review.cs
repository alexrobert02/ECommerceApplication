using ECommerceApplication.Domain.Common;

namespace ECommerceApplication.Domain.Entities
{
    public class Review
    {
        private Review(Guid reviewId, Guid productId, Guid userId, string reviewText, decimal rating)
        {
            ReviewId = reviewId;
            ProductId = productId;
            UserId = userId;
            ReviewText = reviewText;
            Rating = rating;
        }
        public Guid ReviewId { get; set; } 
        public Guid ProductId { get; set;} 
        public Guid UserId { get; set; } 
        public string ReviewText { get; set; } 
        public decimal Rating { get; set; }    
        public static Result<Review> Create(Guid productId, Guid userId, string reviewText, int rating)
        {
            if (productId == default)
            {
                return Result<Review>.Failure("Product id is required.");
            }
            if (userId == default)
            {
                return Result<Review>.Failure("User id is required.");
            }
            if (string.IsNullOrWhiteSpace(reviewText))
            {
                return Result<Review>.Failure("Review text is required.");
            }
            if (rating == default)
            {
                return Result<Review>.Failure("Rating is required.");
            }
            return Result<Review>.Success(new Review(Guid.NewGuid(), productId, userId, reviewText, rating));
        }
        public void AddReview(string reviewText, int rating)
        {
            ReviewText = reviewText;
            Rating = rating;
        }

        public void UpdateReview(string newReviewText, int newRating)
        {
            if (string.IsNullOrWhiteSpace(newReviewText))
            {
                throw new ArgumentException("New review text is required.", nameof(newReviewText));
            }
            if (newRating == default)
            {
                throw new ArgumentException("New rating is required.", nameof(newRating));
            }

            ReviewText = newReviewText;
            Rating = newRating;
        }

        public string GetFormattedReview()
        {
            return $"{Rating} stars - {ReviewText}";
        }

        public bool IsUserAuthorized(Guid requestingUserId)
        {
            return requestingUserId == UserId;
        }
    }
}
