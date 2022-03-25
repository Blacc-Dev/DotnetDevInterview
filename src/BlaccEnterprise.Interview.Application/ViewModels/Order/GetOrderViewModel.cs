using System;

using BlaccEnterprise.Interview.Application.ViewModels.Base;
using BlaccEnterprise.Interview.Domain.Order.Enums;

using Microsoft.AspNetCore.Mvc;

namespace BlaccEnterprise.Interview.Application.ViewModels
{
    public class GetOrderViewModel : PagedAndSortedResultViewModelBase
    {
        [ModelBinder(Name = "filter")]
        public string Filter { get; set; }

        [ModelBinder(Name = "orderNumberFilter")]
        public string OrderNumberFilter { get; set; }

        [ModelBinder(Name = "minOrderDateFilter")]
        public DateTime? MinOrderDateFilter { get; set; }

        [ModelBinder(Name = "maxOrderDateFilter")]
        public DateTime? MaxOrderDateFilter { get; set; }

        [ModelBinder(Name = "minAmountFilter")]
        public double? MinAmountFilter { get; set; }

        [ModelBinder(Name = "maxAmountFilter")]
        public double? MaxAmountFilter { get; set; }

        [ModelBinder(Name = "statusFilter")]
        public EOrderStatus? StatusFilter { get; set; }

        [ModelBinder(Name = "orderSourceFilter")]
        public string OrderSourceFilter { get; set; }
    }
}