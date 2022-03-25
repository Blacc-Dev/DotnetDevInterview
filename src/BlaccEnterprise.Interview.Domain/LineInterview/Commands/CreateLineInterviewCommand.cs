using System;

using BlaccEnterprise.Interview.Domain.LineInterview.Events;

namespace BlaccEnterprise.Interview.Domain.LineInterview.Commands
{
    public class CreateLineInterviewCommand : LineInterviewCommand
    {
        public CreateLineInterviewCommand(int orderId, string productName, int quantity, double amount)
        {
            OrderId = orderId;
            ProductName = productName;
            Quantity = quantity;
            Amount = amount;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateLineInterviewCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}