using ECommerceApplication.Domain.Common;

namespace ECommerceApplication.Domain.Entities
{
    public class Order : AuditableEntity
    {
        private Order() { }
        private Order(ShoppingCart shoppingCart, DateTime orderPlaced, Guid userId)
        {
            OrderId = Guid.NewGuid();
            ShoppingCart = shoppingCart;
            OrderPlaced = orderPlaced;
            UserId = userId;
        }

        public static Result<Order> Create(ShoppingCart shoppingCart, DateTime orderPlaced, Guid userId)
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
            return Result<Order>.Success(new Order(shoppingCart, orderPlaced, userId));
        }
        public Guid OrderId { get; private set; }
        public Guid UserId { get; private set; }
        public ShoppingCart ShoppingCart { get; private set; }
        public DateTime OrderPlaced { get; private set; }
        public bool OrderPaid { get; private set; }
        public Payment Payment { get; private set; }
        public void AddPayment(Payment payment)
        {
                Payment = payment;
        }

        public void MarkAsPaid()
        {
            if (Payment.IsPaymentValid())
            {
                OrderPaid = true;
            }
        }
    }
}
