using System;

using BlaccEnterprise.Interview.Domain.Order.Events;

namespace BlaccEnterprise.Interview.Domain.Order.Commands
{
    public class RemoveOrderCommand : OrderCommand
    {
        public RemoveOrderCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveOrderCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}