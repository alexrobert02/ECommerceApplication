using ECommerceApplication.Domain.Common;

namespace ECommerceApplication.Domain.Entities
{
    public class Company : AuditableEntity
    {
        private Company(string companyName, string companyAddress, string phoneNumber, string email)
        {
            CompanyId = Guid.NewGuid();
            CompanyName = companyName;
            CompanyAddress = companyAddress;
            PhoneNumber = phoneNumber;
            Email = email;
            Products = new List<Product>();
        }

        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Product> Products { get; set; }

        public static Result<Company> Create(string companyName, string companyAddress, string phoneNumber, string email)
        {
            if (string.IsNullOrWhiteSpace(companyName))
            {
                return Result<Company>.Failure("Company Name is required.");
            }
            if (string.IsNullOrWhiteSpace(companyAddress))
            {
                return Result<Company>.Failure("Company Address is required.");
            }
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return Result<Company>.Failure("Phone number is required.");
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                return Result<Company>.Failure("Email is required.");
            }

            return Result<Company>.Success(new Company(companyName, companyAddress, phoneNumber, email));
        }

        public void Update(string name, string address, string phoneNumber, string email)
        {
            CompanyName = name;
            CompanyAddress = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        /*public IEnumerable<Product> GetProducts()
        {
            if (Products == null || !Products.Any())
            {
                throw new InvalidOperationException("No products available from this manufacturer.");
            }

            return Products.AsEnumerable();
        }*/

        /*public void RemoveProduct(Guid productId)
        {
            if (Products == null || !Products.Any())
            {
                throw new InvalidOperationException("No products available from this company.");
            }

            var productToRemove = Products.FirstOrDefault(p => p.ProductId == productId);

            if (productToRemove != null)
            {
                Products.Remove(productToRemove);
            }
            else
            {
                throw new InvalidOperationException("Product not found from this company.");
            }
        }*/

    }
}
