using System.Threading;
using System.Threading.Tasks;

using BlaccEnterprise.Interview.Domain.LineInterview.Events;

using MediatR;

namespace BlaccEnterprise.Interview.Domain.LineInterview.EventHandlers
{
    public class LineInterviewEventHandler :
        INotificationHandler<LineInterviewCreatedEvent>,
        INotificationHandler<LineInterviewUpdatedEvent>,
        INotificationHandler<LineInterviewRemovedEvent>
    {
        public Task Handle(LineInterviewUpdatedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(LineInterviewCreatedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(LineInterviewRemovedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}