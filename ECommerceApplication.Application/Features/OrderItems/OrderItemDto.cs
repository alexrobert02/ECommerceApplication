﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.Features.OrderItems
{
    public class OrderItemDto
    {
        public Guid OrderItemId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
    }
}