using System;

using BlaccEnterprise.Interview.Domain.CargoInterview.Events;

namespace BlaccEnterprise.Interview.Domain.CargoInterview.Commands
{
    public class RemoveCargoInterviewCommand : CargoInterviewCommand
    {
        public RemoveCargoInterviewCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveCargoInterviewCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}