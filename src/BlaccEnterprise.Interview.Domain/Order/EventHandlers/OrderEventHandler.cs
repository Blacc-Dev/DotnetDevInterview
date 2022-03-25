using System.Threading;
using System.Threading.Tasks;

using BlaccEnterprise.Interview.Domain.Order.Events;

using MediatR;

namespace BlaccEnterprise.Interview.Domain.Order.EventHandlers
{
    public class OrderEventHandler :
        INotificationHandler<OrdersImportedEvent>,
        INotificationHandler<OrderCreatedEvent>,
        INotificationHandler<OrderUpdatedEvent>,
        INotificationHandler<OrderRemovedEvent>
    {
        public Task Handle(OrdersImportedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderUpdatedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderCreatedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderRemovedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}