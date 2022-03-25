using System;

using BlaccEnterprise.Interview.Domain.Order.Commands;

using FluentValidation;

namespace BlaccEnterprise.Interview.Domain.Order.Events
{
    public abstract class OrderValidation<T> : AbstractValidator<T> where T : OrderCommand
    {
        protected void ValidateOrderNumber()
        {
            RuleFor(c => c.OrderNumber).NotEmpty().WithMessage("Please ensure you have entered the Order Number.");
        }

        protected void ValidateOrderDate()
        {
            RuleFor(c => c.OrderDate)
                .NotEmpty()
                .Must(GraterThanToday)
                .WithMessage("The order date must be grater than today.");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id).NotEqual(default(int));
        }

        protected static bool GraterThanToday(DateTime orderDate)
        {
            return orderDate > DateTime.Now;
        }
    }
}