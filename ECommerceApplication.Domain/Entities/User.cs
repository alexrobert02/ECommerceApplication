using ECommerceApplication.Domain.Common;
using System.Reflection.Metadata;

namespace ECommerceApplication.Domain.Entities
{
    public class User : AuditableEntity
    {
        private User(string username, string email, string passwordHash, string firstName, string lastName, string address, string phoneNumber)
        {
            UserId = Guid.NewGuid();
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public Guid UserId { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }

        public List<Order>? Orders { get; private set; }

        public static Result<User> Create(string username, string email, string passwordhash, string firstname, string lastname, string address, string phonenumber)
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
            if (string.IsNullOrWhiteSpace(address))
            {
                return Result<User>.Failure("Address is required.");
            }
            if (string.IsNullOrWhiteSpace(phonenumber))
            {
                return Result<User>.Failure("Phone number is required.");
            }
            return Result<User>.Success(new User(username, email, passwordhash, firstname, lastname, address, phonenumber));
        }

        public Result<User> Update(string username, string email, string passwordhash, string firstName, string lastName, string address, string phoneNumber)
        {
            // Perform any additional validation if needed
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                return Result<User>.Failure("Invalid input for updating profile.");
            }
            Username = username;
            Email = email;
            PasswordHash = passwordhash;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
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
    }
}
