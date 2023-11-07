using ECommerceApplication.Domain.Common;

namespace ECommerceApplication.Domain.Entities
{
    public class Order : AuditableEntity
    {
        private Order(ShoppingCart shoppingCart, DateTime orderPlaced, Guid userId, Payment payment)
        {
            OrderId = Guid.NewGuid();
            ShoppingCart = shoppingCart;
            OrderPlaced = orderPlaced;
            UserId = userId;
            Payment = payment;
        }

        public static Result<Order> Create(ShoppingCart shoppingCart, DateTime orderPlaced, Guid userId, Payment payment)
        {
            if (shoppingCart == null)
            {
                return Result<Order>.Failure("Shopping cart is required.");
            }
            if (orderPlaced == default)
            {
                return Result<Order>.Failure("Order Placed is required.");
            }
            if (userId == default)
            {
                return Result<Order>.Failure("User id should not be default");
            }
            if (payment == null)
            {
                return Result<Order>.Failure("Payment is required.");
            }
            return Result<Order>.Success(new Order(shoppingCart, orderPlaced, userId, payment));
        }
        public Guid OrderId { get; private set; }
        public Guid UserId { get; private set; }
        public ShoppingCart ShoppingCart { get; private set; }
        public DateTime OrderPlaced { get; private set; }
        public bool OrderPaid { get; private set; }
        public Payment Payment { get; private set; }

        public void MarkAsPaid()
        {
            if (Payment.IsPaymentValid())
            {
                OrderPaid = true;
            }
        }
    }
}
