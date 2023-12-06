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
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment), "Payment cannot be null.");
            }

            Payment = payment;
        }

        public void MarkAsPaid()
        {
            if (Payment != null && Payment.IsPaymentValid())
            {
                OrderPaid = true;
            }
        }

        public void UpdateUserReward(Reward reward)
        {
            if (OrderPaid)
            {
                reward.UpdateRewardDate(OrderPlaced.AddMonths(3));
                reward.IncreaseReward(ShoppingCart.CalculateTotal() * 0.1m);
            }
        }
        public void CancelOrder()
        {
            if (OrderPaid)
            {
                throw new InvalidOperationException("Cannot cancel a paid order.");
            }
        }

        public void UpdateOrderPlaced(DateTime newOrderPlaced)
        {
            if (newOrderPlaced == default)
            {
                throw new ArgumentException("New order placed date is required.", nameof(newOrderPlaced));
            }

            OrderPlaced = newOrderPlaced;
        }

        public void UpdateShoppingCart(ShoppingCart newShoppingCart)
        {
            if (newShoppingCart == null)
            {
                throw new ArgumentNullException(nameof(newShoppingCart), "New shopping cart is required.");
            }

            ShoppingCart = newShoppingCart;
        }
    }
}
