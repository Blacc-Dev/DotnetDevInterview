using System;

using BlaccEnterprise.Interview.Application.Interfaces;
using BlaccEnterprise.Interview.Infrastructure.Bus;
using BlaccEnterprise.Interview.Infrastructure.Notifications;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlaccEnterprise.Interview.Api.Controllers
{
    [Authorize]
    [Route("api/v1/seed")]
    public class SeedController : ApiController
    {
        private readonly ISeedAppService _seedAppService;

        public SeedController(ISeedAppService seedAppService, INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator, ILogger<ServiceLayerLog> logger) 
            : base(notifications, mediator, logger)
        {
            _seedAppService = seedAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("importOrders")]
        public IActionResult ImportOrders()
        {
            try
            {
                _seedAppService.ImportOrders();
            }
            catch (Exception ex)
            {
                Logger.LogError("Exception when file importing. Exception messag: \r\n" + ex.Message);
            }

            return Ok();
        }
    }
}