using System;

using BlaccEnterprise.Interview.Domain.CargoInterview.Commands;

using FluentValidation;

namespace BlaccEnterprise.Interview.Domain.CargoInterview.Events
{
    public abstract class CargoInterviewValidation<T> : AbstractValidator<T> where T : CargoInterviewCommand
    {
        protected void ValidateCargoInterviewName()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Please ensure you have entered the CargoInterview Number.");
        }

        protected void ValidateCargoInterviewTrackingNumber()
        {
            RuleFor(c => c.TrackingNumber).NotEmpty().WithMessage("Please ensure you have entered the CargoInterview Number.");
        }

        protected void ValidateOrderId()
        {
            RuleFor(c => c.OrderId).NotEqual(default(int));
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id).NotEqual(default(int));
        }
    }
}