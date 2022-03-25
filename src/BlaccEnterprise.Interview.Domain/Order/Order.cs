using System;
using System.Collections.Generic;

using BlaccEnterprise.Interview.Domain.Order.Enums;
using BlaccEnterprise.Interview.Infrastructure.Entities;
using BlaccEnterprise.Interview.Infrastructure.Entities.Interfaces;

namespace BlaccEnterprise.Interview.Domain.Order
{
    public class Order : FullAuditedEntityBase, IAggregateRoot
    {
        public Order(string orderNumber, DateTime orderDate, double amount, EOrderStatus status, string orderSource)
        {
            OrderNumber = orderNumber;
            OrderDate = orderDate;
            Amount = amount;
            Status = status;
            OrderSource = orderSource;
        }

        protected Order() { }

        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public double Amount { get; set; }
        public EOrderStatus Status { get; set; }
        public string OrderSource { get; set; }

        public virtual CargoInterview.CargoInterview CargoInterview { get; set; }
        public virtual IEnumerable<LineInterview.LineInterview> LineInterviews { get; set; }
    }
}