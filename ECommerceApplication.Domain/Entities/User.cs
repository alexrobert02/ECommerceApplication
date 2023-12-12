using ECommerceApplication.Domain.Common;

namespace ECommerceApplication.Domain.Entities
{
    public class User : AuditableEntity
    {
        private User(string username, string email, string passwordHash, string firstName, string lastName, string phoneNumber)
        {
            UserId = Guid.NewGuid();
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Reward = new Reward(UserId, null, null);
        }

        public Guid UserId { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        //public string Address { get; private set; }
        public string PhoneNumber { get; private set; }

        public Reward Reward { get; private set; }
        public List<Order>? Orders { get; private set; }
        public List<Review>? Reviews { get; private set; }
        public List<Address>? Addresses { get; private set; }
        public List<Product>? FavoriteProducts { get; private set; }

        public static Result<User> Create(string username, string email, string passwordhash, string firstname, string lastname, string phonenumber)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return Result<User>.Failure("Username is required.");
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                return Result<User>.Failure("Email is required.");
            }
            if (string.IsNullOrWhiteSpace(passwordhash))
            {
                return Result<User>.Failure("Password is required.");
            }
            if (string.IsNullOrWhiteSpace(firstname))
            {
                return Result<User>.Failure("First name is required.");
            }
            if (string.IsNullOrWhiteSpace(lastname))
            {
                return Result<User>.Failure("Last name is required.");
            }
            if (string.IsNullOrWhiteSpace(phonenumber))
            {
                return Result<User>.Failure("Phone number is required.");
            }
            return Result<User>.Success(new User(username, email, passwordhash, firstname, lastname, phonenumber));
        }

        public Result<User> Update(string username, string email, string passwordhash, string firstName, string lastName, string address, string phoneNumber)
        {
            // Perform any additional validation if needed
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                return Result<User>.Failure("Invalid input for updating profile.");
            }
            Username = username;
            Email = email;
            PasswordHash = passwordhash;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;

            return Result<User>.Success(this);
        }

        public void AddOrder(Order order)
        {
            if (Orders == null)
            {
                Orders = new List<Order>();
            }
            Orders.Add(order);
        }

        public bool HasOrders()
        {
            return Orders != null && Orders.Count > 0;
        }

        public void ChangePassword(string newPasswordHash)
        {
            PasswordHash = newPasswordHash;
        }

        public bool IsPasswordCorrect(string enteredPassword)
        {
            return PasswordHash == enteredPassword;
        }

        public void UpdateEmailAddress(string newEmail)
        {
            Email = newEmail;
        }

        public void UpdatePhoneNumber(string newPhoneNumber)
        {
            PhoneNumber = newPhoneNumber;
        }

        public void AddAddress(Address address)
        {
            if (Addresses == null)
            {
                Addresses = new List<Address>();
            }
            Addresses.Add(address);
        }

        public void RemoveAddress(Guid addressId)
        {
            var addressToRemove = Addresses?.FirstOrDefault(a => a.AddressId == addressId);
            Addresses?.Remove(addressToRemove);
        }

        public bool HasAddresses()
        {
            return Addresses != null && Addresses.Count > 0;
        }


        public void AddToFavorites(Product product)
        {
            if (FavoriteProducts == null)
            {
                FavoriteProducts = new List<Product>();
            }
            FavoriteProducts.Add(product);
        }

        public void RemoveFromFavorites(Guid productId)
        {
            var productToRemove = FavoriteProducts?.FirstOrDefault(p => p.ProductId == productId);
            FavoriteProducts?.Remove(productToRemove);
        }

        public bool IsFavorite(Product product)
        {
            return FavoriteProducts?.Any(p => p.ProductId == product.ProductId) ?? false;
        }
    }
}
