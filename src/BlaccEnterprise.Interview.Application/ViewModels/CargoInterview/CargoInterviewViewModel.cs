using Microsoft.AspNetCore.Mvc;

namespace BlaccEnterprise.Interview.Application.ViewModels.CargoInterview
{
    public class CargoInterviewViewModel
    {
        [ModelBinder(Name = "orderId")]
        public int OrderId { get; set; }

        [ModelBinder(Name = "name")]
        public string Name { get; set; }

        [ModelBinder(Name = "trackingNumber")]
        public string TrackingNumber { get; set; }
    }
}