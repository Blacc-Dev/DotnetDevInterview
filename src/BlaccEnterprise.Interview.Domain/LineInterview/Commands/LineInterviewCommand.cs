using System;

using BlaccEnterprise.Interview.Infrastructure.Commands;

namespace BlaccEnterprise.Interview.Domain.LineInterview.Commands
{
    public abstract class LineInterviewCommand : Command
    {
        public int Id { get; protected set; }

        public int OrderId { get; protected set; }
        public string ProductName { get; protected set; }
        public int Quantity { get; protected set; }
        public double Amount { get; protected set; }
    }
}