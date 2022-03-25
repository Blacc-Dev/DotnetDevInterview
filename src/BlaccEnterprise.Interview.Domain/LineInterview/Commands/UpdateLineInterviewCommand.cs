using BlaccEnterprise.Interview.Domain.LineInterview.Events;

namespace BlaccEnterprise.Interview.Domain.LineInterview.Commands
{
    public class UpdateLineInterviewCommand : LineInterviewCommand
    {
        public UpdateLineInterviewCommand(int id, int orderId, string productName, int quantity, double amount)
        {
            Id = id;

            OrderId = orderId;
            ProductName = productName;
            Quantity = quantity;
            Amount = amount;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateLineInterviewCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}