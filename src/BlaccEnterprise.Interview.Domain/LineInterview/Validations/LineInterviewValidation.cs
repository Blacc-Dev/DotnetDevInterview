using BlaccEnterprise.Interview.Domain.LineInterview.Commands;

using FluentValidation;

namespace BlaccEnterprise.Interview.Domain.LineInterview.Events
{
    public abstract class LineInterviewValidation<T> : AbstractValidator<T> where T : LineInterviewCommand
    {
        protected void ValidateLineInterviewProductName()
        {
            RuleFor(c => c.ProductName).NotEmpty().WithMessage("Please ensure you have entered the CargoInterview ProductName.");
        }

        protected void ValidateLineInterviewQuantity()
        {
            RuleFor(c => c.Quantity).GreaterThan(default(int)).WithMessage("Please ensure you have entered the CargoInterview Quantity.");
        }

        protected void ValidateLineInterviewAmount()
        {
            RuleFor(c => c.Amount).GreaterThan(default(int)).WithMessage("Please ensure you have entered the CargoInterview Amount.");
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