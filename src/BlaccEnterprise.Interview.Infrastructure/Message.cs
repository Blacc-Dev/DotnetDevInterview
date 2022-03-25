using System;

using MediatR;

namespace BlaccEnterprise.Interview.Infrastructure
{
    public abstract class Message : IRequest<bool>
    {
        public string Action { get; protected set; }
        public int AggregateId { get; protected set; }

        protected Message()
        {
            Action = GetType().Name;
        }
    }
}