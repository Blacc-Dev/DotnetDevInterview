using BlaccEnterprise.Interview.Infrastructure.DomainEvents;

namespace BlaccEnterprise.Interview.Domain.LineInterview.Events
{
    public class LineInterviewCreatedEvent : DomainEvent
    {
        public LineInterviewCreatedEvent(int id, int orderId, string productName, int quantity, double amount)
        {
            Id = id;
            AggregateId = id;

            OrderId = orderId;
            ProductName = productName;
            Quantity = quantity;
            Amount = amount;
        }

        public int Id { get; set; }

        public int OrderId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public double Amount { get; private set; }
    }
}