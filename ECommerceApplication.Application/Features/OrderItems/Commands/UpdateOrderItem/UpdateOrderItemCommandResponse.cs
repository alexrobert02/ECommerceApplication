using ECommerceApplication.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.Features.OrderItems.Commands.UpdateOrderItem
{
    public class UpdateOrderItemCommandResponse : BaseResponse
    {
        public UpdateOrderItemCommandResponse() : base()
        {
        }
        public UpdateOrderItemDto OrderItem { get; set; }
    }
}
