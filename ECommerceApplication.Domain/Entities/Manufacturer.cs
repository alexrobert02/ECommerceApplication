using ECommerceApplication.Domain.Common;

namespace ECommerceApplication.Domain.Entities
{
    public class Manufacturer : AuditableEntity
    {
        private Manufacturer(string name, string address, string phoneNumber, string email)
        {
            ManufacturerId = Guid.NewGuid();
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public Guid ManufacturerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Product>? Products { get; set; }

        public static Result<Manufacturer> Create(string name, string address, string phoneNumber, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result<Manufacturer>.Failure("Name is required.");
            }
            if (string.IsNullOrWhiteSpace(address))
            {
                return Result<Manufacturer>.Failure("Address is required.");
            }
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return Result<Manufacturer>.Failure("Phone number is required.");
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                return Result<Manufacturer>.Failure("Email is required.");
            }

            return Result<Manufacturer>.Success(new Manufacturer(name, address, phoneNumber, email));
        }

        public void Update(string name, string address, string phoneNumber, string email)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public void AddProduct(Product product)
        {
            if (Products == null)
            {
                Products = new List<Product>();
            }
            Products.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            if (Products == null || !Products.Any())
            {
                throw new InvalidOperationException("No products available from this manufacturer.");
            }

            return Products.AsEnumerable();
        }

        public void RemoveProduct(Guid productId)
        {
            if (Products == null || !Products.Any())
            {
                throw new InvalidOperationException("No products available from this manufacturer.");
            }

            var productToRemove = Products.FirstOrDefault(p => p.ProductId == productId);

            if (productToRemove != null)
            {
                Products.Remove(productToRemove);
            }
            else
            {
                throw new InvalidOperationException("Product not found from this manufacturer.");
            }
        }

        public void UpdateContactInformation(string newPhoneNumber, string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newPhoneNumber) && string.IsNullOrWhiteSpace(newEmail))
            {
                throw new ArgumentException("At least a new phone number or email is required for updating contact information.");
            }

            PhoneNumber = newPhoneNumber ?? PhoneNumber;
            Email = newEmail ?? Email;
        }

    }
}
