using BlaccEnterprise.Interview.Application.Interfaces;
using BlaccEnterprise.Interview.Application.Reporting.Interfaces;
using BlaccEnterprise.Interview.Application.ViewModels;
using BlaccEnterprise.Interview.Infrastructure.Bus;
using BlaccEnterprise.Interview.Infrastructure.Notifications;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlaccEnterprise.Interview.Api.Controllers
{
    [Authorize]
    [Route("api/v1/orders")]
    public class OrderController : ApiController
    {
        private readonly IOrderAppService _orderAppService;
        private readonly IReportingAppService _reportingAppService;

        public OrderController(IOrderAppService orderAppService, IReportingAppService reportingAppService, INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator, ILogger<ServiceLayerLog> logger) 
            : base(notifications, mediator, logger)
        {
            _orderAppService = orderAppService;
            _reportingAppService = reportingAppService;
        }

        [HttpGet]
        public IActionResult Get(GetOrderViewModel input)
        {
            return Response(_orderAppService.Get(input));
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            var orderViewModel = _orderAppService.GetById(id);

            return Response(orderViewModel);
        }

        [HttpPost]
        public IActionResult Post(CreateOrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(orderViewModel);
            }

            _orderAppService.Create(orderViewModel);

            return Response(orderViewModel);
        }

        [HttpPut]
        public IActionResult Put(UpdateOrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(orderViewModel);
            }

            _orderAppService.Update(orderViewModel);

            return Response(orderViewModel);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            _orderAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        [Route("reports/bestSellingProduct")]
        public IActionResult BestSellingProduct()
        {
            var bestSellingProducts = _reportingAppService.GetBestSellingProduct();
            return Response(bestSellingProducts);
        }

        [HttpGet]
        [Route("history/{id:int}")]
        public IActionResult History(int id)
        {
            var orderHistoryData = _orderAppService.GetAllHistory(id);
            return Response(orderHistoryData);
        }
    }
}