using ECommerceApplication.Domain.Common;

namespace ECommerceApplication.Domain.Entities
{
    public class Category : AuditableEntity
    {
        private Category(string categoryName)
        {
            CategoryId = Guid.NewGuid();
            CategoryName = categoryName;
        }

        public Guid CategoryId { get; private set; }
        public string CategoryName { get; private set; } = string.Empty;
        public List<Product>? Products { get; private set; }

        public static Result<Category> Create(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                return Result<Category>.Failure("Category Name is required.");
            }
            return Result<Category>.Success(new Category(categoryName));
        }

        public Result<Category> Update(string categoryName, List<Product> products)
        {
            if (string.IsNullOrWhiteSpace(categoryName) || products == default)
            {
                return Result<Category>.Failure("Invalid input for updating profile.");
            }
            CategoryName = categoryName;
            Products = products;

            return Result<Category>.Success(this);
        }

        public void AttachProduct(Product productItem)
        {
            if (Products == null)
            {
                Products = new List<Product>();
            }
            Products.Add(productItem);
        }

        public Product GetProductById(Guid productId)
        {
            if (Products == null)
            {
                return null;
            }

            var product = Products.FirstOrDefault(p => p.ProductId == productId);

            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            if (Products == null || !Products.Any())
            {
                return Enumerable.Empty<Product>();
            }

            return Products.AsEnumerable();
        }

        public bool UpdateCategoryName(string newCategoryName)
        {
            if (string.IsNullOrWhiteSpace(newCategoryName))
            {
                return false;
            }

            CategoryName = newCategoryName;
            return true;
        }

        public bool RemoveProduct(Guid productId)
        {
            if (Products == null || !Products.Any())
            {
                return false;
            }

            var productToRemove = Products.FirstOrDefault(p => p.ProductId == productId);

            if (productToRemove != null)
            {
                Products.Remove(productToRemove);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
