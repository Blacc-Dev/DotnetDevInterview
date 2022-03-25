using System;

using BlaccEnterprise.Interview.Domain.Order.Enums;
using BlaccEnterprise.Interview.Infrastructure.DomainEvents;

namespace BlaccEnterprise.Interview.Domain.Order.Events
{
    public class OrderUpdatedEvent : DomainEvent
    {
        public OrderUpdatedEvent(int id, string orderNumber, DateTime orderDate, double amount, EOrderStatus status, string orderSource)
        {
            Id = id;
            AggregateId = id;

            OrderNumber = orderNumber;
            OrderDate = orderDate;
            Amount = amount;
            Status = status;
            OrderSource = orderSource;
        }

        public int Id { get; set; }

        public string OrderNumber { get; private set; }
        public DateTime OrderDate { get; private set; }
        public double Amount { get; private set; }
        public EOrderStatus Status { get; private set; }
        public string OrderSource { get; private set; }
    }
}