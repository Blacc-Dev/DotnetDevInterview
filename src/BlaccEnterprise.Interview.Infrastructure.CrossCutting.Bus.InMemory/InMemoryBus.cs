using System.Threading.Tasks;

using BlaccEnterprise.Interview.Infrastructure.Bus;
using BlaccEnterprise.Interview.Infrastructure.Commands;
using BlaccEnterprise.Interview.Infrastructure.DomainEvents;

using MediatR;

namespace BlaccEnterprise.Interview.Infrastructure.CrossCutting.Bus.InMemory
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IDomainEventStore _eventStore;

        public InMemoryBus(IDomainEventStore eventStore, IMediator mediator)
        {
            _eventStore = eventStore;
            _mediator = mediator;
        }

        public async Task RaiseEvent<T>(T @event) where T : DomainEvent
        {
            if (!@event.Action.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            await _mediator.Publish(@event);
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
    }
}