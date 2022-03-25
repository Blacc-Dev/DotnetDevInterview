using System.Collections.Generic;
using System.Linq;

using BlaccEnterprise.Interview.Infrastructure.Bus;
using BlaccEnterprise.Interview.Infrastructure.Notifications;

using MediatR;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlaccEnterprise.Interview.Api.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;

        protected readonly ILogger<ServiceLayerLog> Logger;

        protected ApiController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator, ILogger<ServiceLayerLog> logger)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;

            Logger = logger;
        }

        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

        protected bool IsValidOperation()
        {
            return !_notifications.HasNotifications();
        }

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    Success = true,
                    Data = result
                });
            }

            Logger.LogWarning(string.Join(',', _notifications.GetNotifications().Select(n => n.Value)));

            return BadRequest(new
            {
                Success = false,
                Errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        protected void NotifyModelStateErrors()
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;

                NotifyError(string.Empty, errorMessage);

                Logger.LogWarning(string.Join(',', _notifications.GetNotifications().Select(n => n.Value)));
            }
        }

        protected void NotifyError(string code, string message)
        {
            _mediator.RaiseEvent(new DomainNotification(code, message));
        }

        protected void AddIdentityErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
                NotifyError(result.ToString(), error.Description);
        }
    }
}
