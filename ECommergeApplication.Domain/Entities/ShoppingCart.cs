using ECommerceApplication.Domain.Common;
using ECommerceApplication.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Domain.Entities
{
    public class ShoppingCart : AuditableEntity
    {
        private ShoppingCart(Guid userId)
        {
            ShoppingCartId = Guid.NewGuid();
            UserId = userId;
            Products = new List<Product>();
        }

        public Guid ShoppingCartId { get; private set; }
        public Guid UserId { get; private set; }
        public List<Product>? Products { get; private set; }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(Guid productId)
        {
            var productToRemove = Products.Find(product => product.ProductId == productId);

            if (productToRemove != null)
            {
                Products.Remove(productToRemove);
            }
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;

            foreach (Product product in Products)
            {
                total += product.Price;
            }

            return total;
        }
    }
}
