using ECommerceApplication.Domain.Common;

namespace ECommerceApplication.Domain.Entities
{
    public class OrderItem : AuditableEntity
    {
        public Guid OrderItemId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal PricePerUnit { get; private set; }

        private OrderItem(Guid productId, int quantity, decimal pricePerUnit)
        {
            OrderItemId = Guid.NewGuid();
            ProductId = productId;
            Quantity = quantity;
            PricePerUnit = pricePerUnit;
        }

        public static Result<OrderItem> Create(Guid productId, int quantity, decimal pricePerUnit)
        {
            if (productId == default)
            {
                return Result<OrderItem>.Failure("Product id is required.");
            }

            if (quantity <= 0)
            {
                return Result<OrderItem>.Failure("Quantity must be greater than zero.");
            }

            if (pricePerUnit <= 0)
            {
                return Result<OrderItem>.Failure("Price per unit must be greater than zero.");
            }

            return Result<OrderItem>.Success(new OrderItem(productId, quantity, pricePerUnit));
        }

        public void UpdateQuantity(int newQuantity)
        {
            if (newQuantity > 0)
            {
                Quantity = newQuantity;
            }
            else
                throw new InvalidOperationException("Invalid quantity. Quantity should be greater than zero.");
        }

        public void UpdatePricePerUnit(decimal newPricePerUnit)
        {
            if (newPricePerUnit > 0)
            {
                PricePerUnit = newPricePerUnit;
            }
            else
                throw new InvalidOperationException("Invalid price. Price per unit should be greater than zero.");
        }

        public decimal CalculateTotal()
        {
            return Quantity * PricePerUnit;
        }

        public void IncreaseQuantity(int amount)
        {
            if (amount > 0)
            {
                Quantity += amount;
            }
            else
                throw new InvalidOperationException("Invalid quantity increment. Quantity should be greater than zero.");
        }

        public void DecreaseQuantity(int amount)
        {
            if (amount > 0 && Quantity >= amount)
            {
                Quantity -= amount;
            }
            else
                throw new InvalidOperationException("Invalid quantity decrement. Quantity should be greater than zero and not exceed current quantity.");
        }
    }
}
