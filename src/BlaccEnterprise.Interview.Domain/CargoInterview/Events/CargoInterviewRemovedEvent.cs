using System;

using BlaccEnterprise.Interview.Infrastructure.DomainEvents;

namespace BlaccEnterprise.Interview.Domain.CargoInterview.Events
{
    public class CargoInterviewRemovedEvent : DomainEvent
    {
        public CargoInterviewRemovedEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public int Id { get; set; }
    }
}