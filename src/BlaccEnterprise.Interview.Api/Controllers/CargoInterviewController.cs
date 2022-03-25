using BlaccEnterprise.Interview.Application.Interfaces;
using BlaccEnterprise.Interview.Application.ViewModels.CargoInterview;
using BlaccEnterprise.Interview.Infrastructure.Bus;
using BlaccEnterprise.Interview.Infrastructure.Notifications;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlaccEnterprise.Interview.Api.Controllers
{
    [Authorize]
    [Route("api/v1/orders/{orderId}/cargoInterviews")]
    public class CargoInterviewController : ApiController
    {
        private readonly ICargoInterviewAppService _cargoInterviewAppService;

        public CargoInterviewController(ICargoInterviewAppService cargoInterviewAppService, INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator, ILogger<ServiceLayerLog> logger)
            : base(notifications, mediator, logger)
        {
            _cargoInterviewAppService = cargoInterviewAppService;
        }

        [HttpGet]
        public IActionResult Get(GetCargoInterviewViewModel input)
        {
            return Response(_cargoInterviewAppService.Get(input));
        }

        //[HttpGet]
        //[Route("{id:int}")]
        //public IActionResult Get(int id)
        //{
        //    var cargoInterviewViewModel = _cargoInterviewAppService.GetById(id);

        //    return Response(cargoInterviewViewModel);
        //}

        //[HttpPost]
        //public IActionResult Post(CreateCargoInterviewViewModel cargoInterviewViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        NotifyModelStateErrors();
        //        return Response(cargoInterviewViewModel);
        //    }

        //    _cargoInterviewAppService.Create(cargoInterviewViewModel);

        //    return Response(cargoInterviewViewModel);
        //}

        [HttpPut]
        public IActionResult Put(UpdateCargoInterviewViewModel cargoInterviewViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(cargoInterviewViewModel);
            }

            _cargoInterviewAppService.Update(cargoInterviewViewModel);

            return Response(cargoInterviewViewModel);
        }

        //[HttpDelete]
        //[Route("{id:int}")]
        //public IActionResult Delete(int id)
        //{
        //    _cargoInterviewAppService.Remove(id);

        //    return Response();
        //}
    }
}