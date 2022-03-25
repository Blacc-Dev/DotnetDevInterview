using System;

using BlaccEnterprise.Interview.Domain.Order.Events;
using BlaccEnterprise.Interview.Infrastructure.Commands;

namespace BlaccEnterprise.Interview.Domain.Order.Commands
{
    public class ImportOrdersCommand : Command
    {
        public string FilePath { get; protected set; }

        public ImportOrdersCommand(string path)
        {
            FilePath = path;
        }

        public override bool IsValid()
        {
            ValidationResult = new ImportOrdersCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}