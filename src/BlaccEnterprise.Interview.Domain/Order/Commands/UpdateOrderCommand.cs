using System;

using BlaccEnterprise.Interview.Domain.Order.Enums;
using BlaccEnterprise.Interview.Domain.Order.Events;

namespace BlaccEnterprise.Interview.Domain.Order.Commands
{
    public class UpdateOrderCommand : OrderCommand
    {
        public UpdateOrderCommand(int id, string orderNumber, DateTime orderDate, double amount, EOrderStatus status, string orderSource)
        {
            Id = id;
            OrderNumber = orderNumber;
            OrderDate = orderDate;
            Amount = amount;
            Status = status;
            OrderSource = orderSource;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateOrderCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}