using System;

using BlaccEnterprise.Interview.Domain.Order.Enums;
using BlaccEnterprise.Interview.Domain.Order.Events;

namespace BlaccEnterprise.Interview.Domain.Order.Commands
{
    public class CreateOrderCommand : OrderCommand
    {
        public CreateOrderCommand(string orderNumber, DateTime orderDate, double amount, EOrderStatus status, string orderSource)
        {
            OrderNumber = orderNumber;
            OrderDate = orderDate;
            Amount = amount;
            Status = status;
            OrderSource = orderSource;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateOrderCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}