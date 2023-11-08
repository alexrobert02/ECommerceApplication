using ECommerceApplication.Domain.Common;

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
        public static Result<Payment> Create(Guid orderId, decimal amount, DateTime paymentDate, string paymentMethod)
        {
            if (orderId == default)
            {
                return Result<Payment>.Failure("Order id is required.");
            }
            if (amount == default)
            {
                return Result<Payment>.Failure("Amount is required.");
            }
            if (paymentDate == default)
            {
                return Result<Payment>.Failure("Payment date is required.");
            }
            if (string.IsNullOrWhiteSpace(paymentMethod))
            {
                return Result<Payment>.Failure("Payment method is required.");
            }
            return Result<Payment>.Success(new Payment(Guid.NewGuid(), orderId, amount, paymentDate, paymentMethod));
        }

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
