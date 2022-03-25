using BlaccEnterprise.Interview.Application.ViewModels.Base;

using Microsoft.AspNetCore.Mvc;

namespace BlaccEnterprise.Interview.Application.ViewModels.CargoInterview
{
    public class GetCargoInterviewViewModel : PagedAndSortedResultViewModelBase
    {
        [ModelBinder(Name = "filter")]
        public string Filter { get; set; }

        [ModelBinder(Name = "orderId")]
        public int OrderId { get; set; }

        [ModelBinder(Name = "nameFilter")]
        public string NameFilter { get; set; }

        [ModelBinder(Name = "trackingNumberFilter")]
        public string TrackingNumberFilter { get; set; }
    }
}