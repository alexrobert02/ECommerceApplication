﻿using ECommerceApplication.Domain.Entities;
using ECommerceApplication.Infrastructure;

namespace ECommerceApplication.API.IntegrationTests.Base
{
    public class Seed
    {
        public static void InitializeDbForTests(ECommerceApplicationContext context)
        {
            var categories = new List<Category>
            {
                Category.Create("Concerts").Value,
                Category.Create("Sports").Value,
                Category.Create("Theater").Value,
                Category.Create("Comedy").Value
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();

            var addresses = new List<Address>
            {
                Address.Create("Street1", "City1", "State1", "PostalCode1", true).Value,
                Address.Create("Street2", "City2", "State2", "PostalCode2", true).Value
            };

            context.Addresses.AddRange(addresses);
            context.SaveChanges();

            var product1 = Product.Create("Product1", 10).Value;
            product1.AttachCategory(categories[1]);
            product1.AttachDescription("Description1");
            product1.AttachImageUrl("ImageUrl1");

            var product2 = Product.Create("Product2", 20).Value;
            product2.AttachCategory(categories[2]);
            product2.AttachDescription("Description2");
            product2.AttachImageUrl("ImageUrl2");

            var products = new List<Product>
            {
                product1,
                product2
            };

            context.Products.AddRange(products);
            context.SaveChanges();

            var orderItems = new List<OrderItem>
            {
                OrderItem.Create(product1.ProductId, 1, 100).Value,
                OrderItem.Create(product2.ProductId, 2, 200).Value
            };

            context.OrderItem.AddRange(orderItems);
            context.SaveChanges();

        }
    }
}
