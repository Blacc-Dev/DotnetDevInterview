using System.Threading;
using System.Threading.Tasks;

using BlaccEnterprise.Interview.Domain.CargoInterview.Events;

using MediatR;

namespace BlaccEnterprise.Interview.Domain.CargoInterview.EventHandlers
{
    public class CargoInterviewEventHandler :
        INotificationHandler<CargoInterviewCreatedEvent>,
        INotificationHandler<CargoInterviewUpdatedEvent>,
        INotificationHandler<CargoInterviewRemovedEvent>
    {
        public Task Handle(CargoInterviewUpdatedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(CargoInterviewCreatedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(CargoInterviewRemovedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}