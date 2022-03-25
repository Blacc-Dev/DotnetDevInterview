using System;

using BlaccEnterprise.Interview.Infrastructure.DomainEvents;

namespace BlaccEnterprise.Interview.Domain.Order.Events
{
    public class OrdersImportedEvent : DomainEvent
    {
        public OrdersImportedEvent(bool success, DateTime startDate, DateTime endDate)
        {
            Success = success;
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Success { get; set; }
    }
}