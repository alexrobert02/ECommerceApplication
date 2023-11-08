using ECommerceApplication.Domain.Common;

namespace ECommerceApplication.Domain.Entities
{
    public class Manufacturer
    {
        private Manufacturer(Guid manufacturerId, string name, string address, string phoneNumber, string email)
        {
            ManufacturerId = manufacturerId;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        public Guid ManufacturerId { get; set;}
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set;}
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
            return Result<Manufacturer>.Success(new Manufacturer(Guid.NewGuid(), name, address, phoneNumber, email));
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
    }
}
