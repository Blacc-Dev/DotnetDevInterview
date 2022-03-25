using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BlaccEnterprise.Interview.Domain.LineInterview.Commands;
using BlaccEnterprise.Interview.Domain.LineInterview.Events;
using BlaccEnterprise.Interview.Domain.LineInterview.Repositories;
using BlaccEnterprise.Interview.Domain.Order.Repositories;
using BlaccEnterprise.Interview.Infrastructure.Bus;
using BlaccEnterprise.Interview.Infrastructure.Commands;
using BlaccEnterprise.Interview.Infrastructure.Notifications;
using BlaccEnterprise.Interview.Infrastructure.UoW;

using MediatR;

namespace BlaccEnterprise.Interview.Domain.LineInterview.CommandHandlers
{
    public class LineInterviewCommandHandler : CommandHandler,
        IRequestHandler<CreateLineInterviewCommand, bool>,
        IRequestHandler<UpdateLineInterviewCommand, bool>,
        IRequestHandler<RemoveLineInterviewCommand, bool>
    {
        private readonly IMediatorHandler _bus;
        private readonly ILineInterviewRepository _lineInterviewRepository;
        private readonly IOrderRepository _orderRepository;

        public LineInterviewCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications, ILineInterviewRepository lineInterviewRepository, IOrderRepository orderRepository) 
            : base(uow, bus, notifications)
        {
            _bus = bus;
            _lineInterviewRepository = lineInterviewRepository;
            _orderRepository = orderRepository;
        }

        public Task<bool> Handle(CreateLineInterviewCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.FromResult(false);
            }

            var lineInterview = new LineInterview(command.OrderId, command.ProductName, command.Quantity, command.Amount);

            if (_orderRepository.GetAll().FirstOrDefault(m => m.Id == command.OrderId) == null)
            {
                _bus.RaiseEvent(new DomainNotification(command.Action, "The order did not found."));

                return Task.FromResult(false);
            }

            _lineInterviewRepository.Insert(lineInterview);

            if (Commit())
                _bus.RaiseEvent(new LineInterviewCreatedEvent(lineInterview.Id, command.OrderId, command.ProductName, command.Quantity, command.Amount));

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateLineInterviewCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.FromResult(false);
            }

            var existingLineInterview = _lineInterviewRepository.GetById(command.Id);
            existingLineInterview.OrderId = command.OrderId;
            existingLineInterview.ProductName = command.ProductName;
            existingLineInterview.Quantity = command.Quantity;
            existingLineInterview.Amount = command.Amount;

            _lineInterviewRepository.Update(existingLineInterview);

            if (Commit())
                _bus.RaiseEvent(new LineInterviewUpdatedEvent(existingLineInterview.Id, existingLineInterview.OrderId, existingLineInterview.ProductName, existingLineInterview.Quantity, existingLineInterview.Amount));

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveLineInterviewCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _lineInterviewRepository.Remove(message.Id);

            if (Commit())
                _bus.RaiseEvent(new LineInterviewRemovedEvent(message.Id));

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _lineInterviewRepository.Dispose();
        }
    }
}