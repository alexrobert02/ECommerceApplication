﻿namespace ECommerceApplication.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserDto
    {
        public Guid UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
