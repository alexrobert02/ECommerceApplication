using ECommerceApplication.Domain.Common;

namespace ECommerceApplication.Domain.Entities
{
    public class ProductVariation : AuditableEntity
    {
        private ProductVariation() { }

        private ProductVariation(string variationName, decimal price, int stockQuantity, Product product)
        {
            VariationId = Guid.NewGuid();
            VariationName = variationName;
            Price = price;
            StockQuantity = stockQuantity;
            Product = product;
        }

        public Guid VariationId { get; private set; }
        public string VariationName { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public Product Product { get; private set; }
        public bool IsActive { get; private set; } = true;

        public static Result<ProductVariation> Create(string variationName, decimal price, int stockQuantity, Product product)
        {
            if (string.IsNullOrWhiteSpace(variationName))
            {
                return Result<ProductVariation>.Failure("Variation Name is required.");
            }
            if (price <= 0)
            {
                return Result<ProductVariation>.Failure("Price must be greater than zero.");
            }
            if (stockQuantity < 0)
            {
                return Result<ProductVariation>.Failure("Stock quantity cannot be negative.");
            }
            if (product == null)
            {
                return Result<ProductVariation>.Failure("Product is required.");
            }

            return Result<ProductVariation>.Success(new ProductVariation(variationName, price, stockQuantity, product));
        }

        public void UpdateVariation(string variationName, decimal price, int stockQuantity)
        {
            VariationName = variationName;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public void SetStockQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity cannot be negative.");
            }

            StockQuantity = quantity;
        }

        public void IncreaseStockQuantity(int quantity)
        {
            if (quantity > 0)
            {
                StockQuantity += quantity;
            }
        }

        public void DecreaseStockQuantity(int quantity)
        {
            if (quantity > 0 && StockQuantity >= quantity)
            {
                StockQuantity -= quantity;
            }
            else
            {
                var errorMessage = quantity > 0
                    ? "Insufficient stock. Available stock is less than the requested quantity."
                    : "Invalid quantity. Quantity should be greater than zero.";
            }
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice > 0)
            {
                Price = newPrice;
            }
        }

        public void Disable()
        {
            IsActive = false;
        }

        public void Enable()
        {
            IsActive = true;
        }
    }
}
