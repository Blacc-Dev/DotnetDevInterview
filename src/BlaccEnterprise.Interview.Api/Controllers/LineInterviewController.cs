using BlaccEnterprise.Interview.Application.Interfaces;
using BlaccEnterprise.Interview.Application.ViewModels.LineInterview;
using BlaccEnterprise.Interview.Infrastructure.Bus;
using BlaccEnterprise.Interview.Infrastructure.Notifications;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlaccEnterprise.Interview.Api.Controllers
{
    [Authorize]
    [Route("api/v1/orders/{orderId}/lineInterviews")]
    public class LineInterviewController : ApiController
    {
        private readonly ILineInterviewAppService _lineInterviewAppService;

        public LineInterviewController(ILineInterviewAppService lineInterviewAppService, INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator, ILogger<ServiceLayerLog> logger)
            : base(notifications, mediator, logger)
        {
            _lineInterviewAppService = lineInterviewAppService;
        }

        [HttpGet]
        public IActionResult Get(GetLineInterviewViewModel input)
        {
            return Response(_lineInterviewAppService.Get(input));
        }

        //[HttpGet]
        //[Route("{id:int}")]
        //public IActionResult Get(int id)
        //{
        //    var lineInterviewViewModel = _lineInterviewAppService.GetById(id);

        //    return Response(lineInterviewViewModel);
        //}

        //[HttpPost]
        //public IActionResult Post(CreateLineInterviewViewModel lineInterviewViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        NotifyModelStateErrors();
        //        return Response(lineInterviewViewModel);
        //    }

        //    _lineInterviewAppService.Create(lineInterviewViewModel);

        //    return Response(lineInterviewViewModel);
        //}

        [HttpPut]
        public IActionResult Put(UpdateLineInterviewViewModel lineInterviewViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(lineInterviewViewModel);
            }

            _lineInterviewAppService.Update(lineInterviewViewModel);

            return Response(lineInterviewViewModel);
        }

        //[HttpDelete]
        //[Route("{id:int}")]
        //public IActionResult Delete(int id)
        //{
        //    _lineInterviewAppService.Remove(id);

        //    return Response();
        //}
    }
}