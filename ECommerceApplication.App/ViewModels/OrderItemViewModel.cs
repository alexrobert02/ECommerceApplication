﻿using System.ComponentModel.DataAnnotations;

namespace ECommerceApplication.App.ViewModels
{
    public class OrderItemViewModel
    {
        public Guid OrderItemId { get; set; }
        [Required(ErrorMessage = "Product id is required")]
        public Guid ProductId { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "PricePerUnit is required")]
        public decimal PricePerUnit { get; set; }
    }
}