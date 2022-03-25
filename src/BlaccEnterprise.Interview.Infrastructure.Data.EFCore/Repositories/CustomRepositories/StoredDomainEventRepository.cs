using System;
using System.Collections.Generic;
using System.Linq;

using BlaccEnterprise.Interview.Infrastructure.DomainEvents;
using BlaccEnterprise.Interview.Infrastructure.Repositories;

namespace BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Repositories.CustomRepositories
{
    public class StoredDomainEventRepository : GenericRepository<StoredDomainEvent, StoredDomainEventEFCoreContext>, IStoredDomainEventRepository
    {
        public StoredDomainEventRepository(StoredDomainEventEFCoreContext context) : base(context) { }

        public IList<StoredDomainEvent> GetHistoriesByAggregateId(int aggregateId)
        {
            return DbSet.Where(m => m.AggregateId == aggregateId).ToArray();
        }

        public void Store(StoredDomainEvent @event)
        {
            DbSet.Add(@event);

            SaveChanges();
        }
    }
}
