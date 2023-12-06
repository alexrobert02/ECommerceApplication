using ECommerceApplication.Domain.Common;

namespace ECommerceApplication.Domain.Entities
{
    public class Product : AuditableEntity
    {
        private Product(string productName, decimal price)
        {
            ProductId = Guid.NewGuid();
            ProductName = productName;
            Price = price;
        }
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public string? Description { get; private set; }
        public string? ImageUrl { get; private set; }
        public List<Review>? Reviews { get; private set; }
        //public Manufacturer Manufacturer { get; private set; }
        //public Guid ManufacturerId { get; private set; }

        public static Result<Product> Create(string productName, decimal price)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                return Result<Product>.Failure("Product Name is required.");
            }
            if (price <= 0)
            {
                return Result<Product>.Failure("Price must be greater than zero.");
            }
            return Result<Product>.Success(new Product(productName, price));
        }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }

        public void AttachDescription(string description)
        {
            if (!string.IsNullOrWhiteSpace(description))
            {
                Description = description;
            }
        }

        public void AttachImageUrl(string imageUrl)
        {
            if (!string.IsNullOrWhiteSpace(imageUrl))
            {
                ImageUrl = imageUrl;
            }
        }

        public void AttachCategory(Guid categoryId)
        {
            if (categoryId != Guid.Empty)
            {
                CategoryId = categoryId;
            }
        }

        /*public void AttachManufacturer(Guid manufacturerId)
        {
            if (manufacturerId != Guid.Empty)
            {
                ManufacturerId = manufacturerId;
            }
        }*/

        public void AttachReview(Review review)
        {
            if (Reviews == null)
            {
                Reviews = new List<Review>();
            }
            Reviews.Add(review);
        }

        public void Update(string productName, decimal price, string? description, string? imageUrl, Guid categoryId)
        {
            ProductName = productName;
            Price = price;
            Description = description;
            ImageUrl = imageUrl;
            CategoryId = categoryId;
        }

        public void RemoveReview(Guid reviewId)
        {
            if (Reviews == null || !Reviews.Any())
            {
                throw new InvalidOperationException("No reviews available for this product.");
            }

            var reviewToRemove = Reviews.FirstOrDefault(r => r.ReviewId == reviewId);

            if (reviewToRemove != null)
            {
                Reviews.Remove(reviewToRemove);
            }
            else
            {
                throw new InvalidOperationException("Review not found for this product.");
            }
        }

    }
}