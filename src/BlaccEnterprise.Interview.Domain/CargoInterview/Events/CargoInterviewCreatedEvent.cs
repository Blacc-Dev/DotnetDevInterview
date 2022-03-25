using BlaccEnterprise.Interview.Infrastructure.DomainEvents;

namespace BlaccEnterprise.Interview.Domain.CargoInterview.Events
{
    public class CargoInterviewCreatedEvent : DomainEvent
    {
        public CargoInterviewCreatedEvent(int id, int orderId, string name, string trackingNumber)
        {
            Id = id;
            AggregateId = id;

            OrderId = orderId;
            Name = name;
            TrackingNumber = trackingNumber;
        }

        public int Id { get; set; }

        public int OrderId { get; private set; }
        public string Name { get; private set; }
        public string TrackingNumber { get; private set; }
    }
}