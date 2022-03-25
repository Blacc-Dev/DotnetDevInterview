using System;

using MediatR;

namespace BlaccEnterprise.Interview.Infrastructure.DomainEvents
{
    public abstract class DomainEvent : Message, INotification
    {
        protected DomainEvent()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; }
    }
}