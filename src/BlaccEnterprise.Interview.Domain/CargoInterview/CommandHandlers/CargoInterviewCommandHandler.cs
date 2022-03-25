using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BlaccEnterprise.Interview.Domain.CargoInterview.Commands;
using BlaccEnterprise.Interview.Domain.CargoInterview.Events;
using BlaccEnterprise.Interview.Domain.CargoInterview.Repositories;
using BlaccEnterprise.Interview.Domain.Order.Repositories;
using BlaccEnterprise.Interview.Infrastructure.Bus;
using BlaccEnterprise.Interview.Infrastructure.Commands;
using BlaccEnterprise.Interview.Infrastructure.Notifications;
using BlaccEnterprise.Interview.Infrastructure.UoW;

using MediatR;

namespace BlaccEnterprise.Interview.Domain.CargoInterview.CommandHandlers
{
    public class CargoInterviewCommandHandler : CommandHandler,
        IRequestHandler<CreateCargoInterviewCommand, bool>,
        IRequestHandler<UpdateCargoInterviewCommand, bool>,
        IRequestHandler<RemoveCargoInterviewCommand, bool>
    {
        private readonly IMediatorHandler _bus;
        private readonly ICargoInterviewRepository _cargoInterviewRepository;
        private readonly IOrderRepository _orderRepository;

        public CargoInterviewCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications, ICargoInterviewRepository cargoInterviewRepository, IOrderRepository orderRepository) 
            : base(uow, bus, notifications)
        {
            _bus = bus;
            _cargoInterviewRepository = cargoInterviewRepository;
            _orderRepository = orderRepository;
        }

        public Task<bool> Handle(CreateCargoInterviewCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.FromResult(false);
            }

            var cargoInterview = new CargoInterview(command.OrderId, command.Name, command.TrackingNumber);

            if (_orderRepository.GetAll().FirstOrDefault(m => m.Id == command.OrderId) == null)
            {
                _bus.RaiseEvent(new DomainNotification(command.Action, "The order did not found."));

                return Task.FromResult(false);
            }

            _cargoInterviewRepository.Insert(cargoInterview);

            if (Commit())
                _bus.RaiseEvent(new CargoInterviewCreatedEvent(cargoInterview.Id, cargoInterview.OrderId, cargoInterview.Name, cargoInterview.TrackingNumber));

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateCargoInterviewCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.FromResult(false);
            }

            var existingCargoInterview = _cargoInterviewRepository.GetAll().Where(m => m.OrderId == command.OrderId).FirstOrDefault();
            existingCargoInterview.OrderId = command.OrderId;
            existingCargoInterview.Name = command.Name;
            existingCargoInterview.TrackingNumber = command.TrackingNumber;

            _cargoInterviewRepository.Update(existingCargoInterview);

            if (Commit())
                _bus.RaiseEvent(new CargoInterviewUpdatedEvent(existingCargoInterview.Id, existingCargoInterview.OrderId, existingCargoInterview.Name, existingCargoInterview.TrackingNumber));

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveCargoInterviewCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _cargoInterviewRepository.Remove(message.Id);

            if (Commit())
                _bus.RaiseEvent(new CargoInterviewRemovedEvent(message.Id));

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _cargoInterviewRepository.Dispose();
        }
    }
}