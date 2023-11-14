using ECommerceApplication.Domain.Common;

namespace ECommerceApplication.Domain.Entities
{
    public class Address
    {
        private Address(Guid addressId, Guid userId, string street, string city, string state, string postalCode, bool isDefault)
        {
            AddressId = addressId;
            UserId = userId;
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
            IsDefault = isDefault;
        }

        public Guid AddressId { get; private set; }
        public Guid UserId { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }
        public bool IsDefault { get; private set; }

        public static Result<Address> Create(Guid addressId, Guid userId, string street, string city, string state, string postalCode, bool isDefault)
        {
            if (addressId == default)
            {
                return Result<Address>.Failure("Address id is required.");
            }
            if (userId == default)
            {
                return Result<Address>.Failure("User id is required.");
            }
            if (string.IsNullOrWhiteSpace(street))
            {
                return Result<Address>.Failure("Street is required.");
            }
            if (string.IsNullOrWhiteSpace(city))
            {
                return Result<Address>.Failure("City is required.");
            }
            if (string.IsNullOrWhiteSpace(state))
            {
                return Result<Address>.Failure("State is required.");
            }
            if (string.IsNullOrWhiteSpace(postalCode))
            {
                return Result<Address>.Failure("Postal code is required.");
            }

            return Result<Address>.Success(new Address(addressId, userId, street, city, state, postalCode, isDefault));
        }

        public void UpdateAddress(string street, string city, string state, string postalCode)
        {
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        public bool MarkAsDefault()
        {
            if (!IsDefault)
            {
                IsDefault = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UnmarkAsDefault()
        {
            if (IsDefault)
            {
                IsDefault = false;
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool IsDefaultAddress()
        {
            return IsDefault;
        }

        public string GetFormattedAddress()
        {
            return $"{Street}, {City}, {State} {PostalCode}";
        }
    }
}
