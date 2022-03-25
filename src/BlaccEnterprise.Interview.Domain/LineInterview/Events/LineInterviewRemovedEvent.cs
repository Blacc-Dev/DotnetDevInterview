using System;

using BlaccEnterprise.Interview.Infrastructure.DomainEvents;

namespace BlaccEnterprise.Interview.Domain.LineInterview.Events
{
    public class LineInterviewRemovedEvent : DomainEvent
    {
        public LineInterviewRemovedEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public int Id { get; set; }
    }
}