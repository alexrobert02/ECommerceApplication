﻿namespace ECommerceApplication.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        //public Guid ManufacturerId { get; private set; }
    }
}

