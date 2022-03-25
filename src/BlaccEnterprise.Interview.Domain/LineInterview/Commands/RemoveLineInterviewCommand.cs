using System;

using BlaccEnterprise.Interview.Domain.LineInterview.Events;

namespace BlaccEnterprise.Interview.Domain.LineInterview.Commands
{
    public class RemoveLineInterviewCommand : LineInterviewCommand
    {
        public RemoveLineInterviewCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveLineInterviewCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}