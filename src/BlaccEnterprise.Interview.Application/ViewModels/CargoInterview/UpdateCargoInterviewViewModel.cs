using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;

namespace BlaccEnterprise.Interview.Application.ViewModels.CargoInterview
{
    public class UpdateCargoInterviewViewModel
    {
        [ModelBinder(Name = "orderId")]
        [Required(ErrorMessage = "The OrderId is Required")]
        public int OrderId { get; set; }

        [ModelBinder(Name = "name")]
        [Required(ErrorMessage = "The Name is Required")]
        public string Name { get; set; }

        [ModelBinder(Name = "trackingNumber")]
        [Required(ErrorMessage = "The TrackingNumber is Required")]
        public string TrackingNumber { get; set; }
    }
}