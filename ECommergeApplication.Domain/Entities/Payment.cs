using ECommerceApplication.Domain.Common;
using ECommerceApplication.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Domain.Entities
{
    public class Payment : AuditableEntity
    {
        private Payment(Guid paymentId, Guid orderId, decimal amount, DateTime paymentDate, string paymentMethod)
        {
            PaymentId = paymentId;
            OrderId = orderId;
            Amount = amount;
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;
        }
        public Guid PaymentId { get; private set; }
        public Guid OrderId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public string PaymentMethod { get; private set; }
        public string PaymentStatus { get; private set; }

        public bool IsPaymentValid()
        {
            if (PaymentStatus == "Paid")
            {
                return true;
            }
            return false;
        }
    }
}
