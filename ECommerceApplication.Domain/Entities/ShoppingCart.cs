using ECommerceApplication.Domain.Common;

namespace ECommerceApplication.Domain.Entities
{
    public class ShoppingCart : AuditableEntity
    {
        private ShoppingCart(Guid userId)
        {
            ShoppingCartId = Guid.NewGuid();
            UserId = userId;
            OrderItems = new List<OrderItem>();
        }

        public Guid ShoppingCartId { get; private set; }
        public Guid UserId { get; private set; }
        public List<OrderItem>? OrderItems { get; private set; }
        public static Result<ShoppingCart> Create(Guid userId)
        {
            if (userId == default)
            {
                return Result<ShoppingCart>.Failure("User id is required.");
            }
            return Result<ShoppingCart>.Success(new ShoppingCart(userId));
        }

        public void AddProduct(OrderItem orderItem)
        {
            if(OrderItems == null)
            {
                OrderItems = new List<OrderItem>();
            }
            OrderItems.Add(orderItem);
        }

        public void RemoveProduct(Guid orderItemId)
        {
            var productToRemove = OrderItems.Find(orderItem => orderItem.OrderItemId == orderItemId);

            if (productToRemove != null)
            {
                OrderItems.Remove(productToRemove);
            }
        }

        public decimal CalculateTotal()
        {
            return OrderItems.Aggregate((decimal) 0, (acc, x) => acc + x.CalculateTotal());
        }

        public void ClearCart()
        {
            OrderItems?.Clear();
        }

        public int GetProductCount()
        {
            return OrderItems?.Count ?? 0;
        }

        public bool IsEmpty()
        {
            return OrderItems == null || !OrderItems.Any();
        }

        public void MergeCarts(ShoppingCart otherCart)
        {
            if (otherCart != null && otherCart.OrderItems != null && otherCart.OrderItems.Any())
            {
                if (OrderItems == null)
                {
                    OrderItems = new List<OrderItem>();
                }

                OrderItems.AddRange(otherCart.OrderItems);
                otherCart.ClearCart();
            }
        }
    }
}
