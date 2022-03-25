using BlaccEnterprise.Interview.Infrastructure.Bus;
using BlaccEnterprise.Interview.Infrastructure.Notifications;
using BlaccEnterprise.Interview.Infrastructure.UoW;

using MediatR;

namespace BlaccEnterprise.Interview.Infrastructure.Commands
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.Action, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications())
                return false;

            if (_uow.CommitTransaction()) 
                return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));

            return false;
        }
    }
}
