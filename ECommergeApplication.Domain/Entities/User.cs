using ECommerceApplication.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Domain.Entities
{
    public class User : AuditableEntity
    {
        private User(Guid userId, string username, string email, string passwordHash, string firstName, string lastName, string address, string phoneNumber, List<Order>? orders)
        {
            UserId = userId;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            Orders = orders;
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
            return Result<User>.Success(new User(Guid.NewGuid(), username, email, passwordhash, firstname, lastname, address, phonenumber, null));
        }

        public void UpdateProfile(string firstName, string lastName, string address, string phoneNumber)
        {

            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
