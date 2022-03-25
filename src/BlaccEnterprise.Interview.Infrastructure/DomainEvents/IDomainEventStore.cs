namespace BlaccEnterprise.Interview.Infrastructure.DomainEvents
{
    public interface IDomainEventStore
    {
        void Save<T>(T @event) where T : DomainEvent;
    }
}