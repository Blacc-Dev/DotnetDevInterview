using System;

namespace BlaccEnterprise.Interview.Infrastructure.DomainEvents
{
    public class StoredDomainEvent : DomainEvent
    {
        public StoredDomainEvent(DomainEvent theEvent, string data, string user)
        {
            Id = Guid.NewGuid();

            AggregateId = theEvent.AggregateId;
            Action = theEvent.Action;
            Data = data;
            User = user;
        }

        // EF Constructor
        protected StoredDomainEvent() { }

        public Guid Id { get; private set; }

        public string Data { get; private set; }

        public string User { get; private set; }
    }
}
