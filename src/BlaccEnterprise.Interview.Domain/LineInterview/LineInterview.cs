using BlaccEnterprise.Interview.Infrastructure.Entities;

namespace BlaccEnterprise.Interview.Domain.LineInterview
{
    public class LineInterview : CreationAuditedEntityBase
    {
        public LineInterview(int orderId, string productName, int quantity, double amount)
        {
            OrderId = orderId;
            ProductName = productName;
            Quantity = quantity;
            Amount = amount;
        }

        protected LineInterview() { }

        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }

        public virtual Order.Order Order { get; set; }
    }
}