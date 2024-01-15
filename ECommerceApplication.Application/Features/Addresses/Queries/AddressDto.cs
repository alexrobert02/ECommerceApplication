﻿namespace ECommerceApplication.Application.Features.Addresses.Queries
{
    public class AddressDto
    {
        public Guid AddressId { get; set; }
        public Guid UserId { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public bool IsDefault { get; set; }
    }
}
