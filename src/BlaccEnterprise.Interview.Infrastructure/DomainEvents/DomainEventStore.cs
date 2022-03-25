using System.Text.Json;

using BlaccEnterprise.Interview.Infrastructure.Repositories;

namespace BlaccEnterprise.Interview.Infrastructure.DomainEvents
{
    public class DomainEventStore : IDomainEventStore
    {
        private readonly IStoredDomainEventRepository _storedDomainEventRepository;
        private readonly IUser _user;

        public DomainEventStore(IStoredDomainEventRepository storedDomainEventRepository, IUser user)
        {
            _storedDomainEventRepository = storedDomainEventRepository;
            _user = user;
        }

        public void Save<T>(T @event) where T : DomainEvent
        {
            var serializedData = JsonSerializer.Serialize(@event, new JsonSerializerOptions
            {
                IgnoreNullValues = false,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });

            var storedDomainEvent = new StoredDomainEvent(
                @event,
                serializedData,
                _user.Name
            );

            _storedDomainEventRepository.Store(storedDomainEvent);
        }
    }
}