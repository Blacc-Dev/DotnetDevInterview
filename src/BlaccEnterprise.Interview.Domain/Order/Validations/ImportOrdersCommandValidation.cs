using BlaccEnterprise.Interview.Domain.Order.Commands;

using FluentValidation;

namespace BlaccEnterprise.Interview.Domain.Order.Events
{
    public class ImportOrdersCommandValidation : AbstractValidator<ImportOrdersCommand>
    {
        public ImportOrdersCommandValidation()
        {
            ValidatePath();
        }

        protected void ValidatePath()
        {
            RuleFor(c => c.FilePath).NotEmpty().WithMessage("File not found.");
        }
    }
}