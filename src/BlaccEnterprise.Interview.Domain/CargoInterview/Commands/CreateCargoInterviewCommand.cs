using BlaccEnterprise.Interview.Domain.CargoInterview.Events;

namespace BlaccEnterprise.Interview.Domain.CargoInterview.Commands
{
    public class CreateCargoInterviewCommand : CargoInterviewCommand
    {
        public CreateCargoInterviewCommand(int orderId, string name, string trackingNumber)
        {
            OrderId = orderId;
            Name = name;
            TrackingNumber = trackingNumber;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateCargoInterviewCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}