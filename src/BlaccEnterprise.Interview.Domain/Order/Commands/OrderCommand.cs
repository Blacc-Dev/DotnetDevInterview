using System;

using BlaccEnterprise.Interview.Domain.Order.Enums;
using BlaccEnterprise.Interview.Infrastructure.Commands;

namespace BlaccEnterprise.Interview.Domain.Order.Commands
{
    public abstract class OrderCommand : Command
    {
        public int Id { get; protected set; }

        public string OrderNumber { get; protected set; }
        public DateTime OrderDate { get; protected set; }
        public double Amount { get; protected set; }
        public EOrderStatus Status { get; protected set; }
        public string OrderSource { get; protected set; }
    }
}