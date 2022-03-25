using System;

using BlaccEnterprise.Interview.Domain.CargoInterview.Events;

namespace BlaccEnterprise.Interview.Domain.CargoInterview.Commands
{
    public class UpdateCargoInterviewCommand : CargoInterviewCommand
    {
        public UpdateCargoInterviewCommand(int orderId, string name, string trackingNumber)
        {
            OrderId = orderId;
            Name = name;
            TrackingNumber = trackingNumber;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCargoInterviewCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}