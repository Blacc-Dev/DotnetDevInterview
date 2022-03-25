using System;
using System.Collections.Generic;

using BlaccEnterprise.Interview.Infrastructure.DomainEvents;

namespace BlaccEnterprise.Interview.Infrastructure.Repositories
{
    public interface IStoredDomainEventRepository : IDisposable
    {
        void Store(StoredDomainEvent @event);
        IList<StoredDomainEvent> GetHistoriesByAggregateId(int aggregateId);
    }
}