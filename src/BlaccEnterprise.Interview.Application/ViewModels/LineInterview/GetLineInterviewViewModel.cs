using BlaccEnterprise.Interview.Application.ViewModels.Base;

using Microsoft.AspNetCore.Mvc;

namespace BlaccEnterprise.Interview.Application.ViewModels.LineInterview
{
    public class GetLineInterviewViewModel : PagedAndSortedResultViewModelBase
    {
        [ModelBinder(Name = "filter")]
        public string Filter { get; set; }

        [ModelBinder(Name = "orderId")]
        public int OrderId { get; set; }

        [ModelBinder(Name = "productNameFilter")]
        public string ProductNameFilter { get; set; }
    }
}